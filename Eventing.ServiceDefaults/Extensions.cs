using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Diagnostics;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Polly;
using Polly.Fallback;

namespace Eventing.ServiceDefaults;

// Adds common .NET Aspire services: service discovery, resilience, health checks, and OpenTelemetry.
// This project should be referenced by each service project in your solution.
// To learn more about using this project, see https://aka.ms/dotnet/aspire/service-defaults
public static class Extensions
{
    private const string HealthEndpointPath = "/health";
    private const string AlivenessEndpointPath = "/alive";

    public static TBuilder AddServiceDefaults<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
    {
        builder.Services.AddRedaction();

        builder.ConfigureOpenTelemetry();

        builder.AddDefaultHealthChecks();

        builder.Services.AddServiceDiscovery();

        builder.Services
            .AddHttpLogging(options =>
            {
                options.CombineLogs = true;
                options.LoggingFields = HttpLoggingFields.All;
            })
            .AddExtendedHttpClientLogging(options =>
            {
                options.LogBody = true;
                options.RequestPathParameterRedactionMode = HttpRouteParameterRedactionMode.None;
            })
            .AddHttpClientLatencyTelemetry();

        builder.Services.ConfigureHttpClientDefaults(http =>
        {
            #region Http Resiliency

            var optionsName = $"{http.Name}-standard";
            http.Services.AddOptions<HttpStandardResilienceOptions>(optionsName);
            http.AddResilienceHandler("standard", (builder1, context) =>
            {
                context.EnableReloads<HttpStandardResilienceOptions>($"{http.Name}-standard");
                var resilienceOptions = context.ServiceProvider
                    .GetRequiredService<IOptionsMonitor<HttpStandardResilienceOptions>>().Get(optionsName);

                var loggerFactory = context.ServiceProvider.GetRequiredService<ILoggerFactory>();
                builder1.AddFallback(new FallbackStrategyOptions<HttpResponseMessage>
                    {
                        FallbackAction = _ =>
                            Outcome.FromResultAsValueTask(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable))
                    })
                    .AddRateLimiter(resilienceOptions.RateLimiter)
                    .AddTimeout(resilienceOptions.TotalRequestTimeout)
                    .AddRetry(resilienceOptions.Retry)
                    .AddCircuitBreaker(resilienceOptions.CircuitBreaker)
                    .AddTimeout(resilienceOptions.AttemptTimeout)
                    .ConfigureTelemetry(loggerFactory)
                    .Build();
            });

            #endregion

            // Turn on service discovery by default
            http.AddServiceDiscovery();
        });

        // Uncomment the following to restrict the allowed schemes for service discovery.
        // builder.Services.Configure<ServiceDiscoveryOptions>(options =>
        // {
        //     options.AllowedSchemes = ["https"];
        // });

        return builder;
    }

    public static TBuilder ConfigureOpenTelemetry<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        // See: https://github.com/dotnet/extensions/tree/main/src/Libraries/Microsoft.Extensions.Telemetry

        builder.Services.AddLatencyContext();

        #region Logging

        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        // Enable log enrichment.
        builder.Logging.EnableEnrichment(options =>
        {
            options.CaptureStackTraces = true;
            options.IncludeExceptionMessage = true;
            options.MaxStackTraceLength = 4096;
            options.UseFileInfoForStackTraces = true;
        });

        builder.Services
            .AddServiceLogEnricher(); // <- This call is required in order for the enricher to be added into the service collection.

        // Add trace-based sampler
        builder.Logging.AddTraceBasedSampler();

        // Enable log redaction
        builder.Logging.EnableRedaction();

        #endregion

        #region Tracing & Metrics

        builder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation()
                    .AddMeter(nameof(Polly));
            })
            .WithTracing(tracing =>
            {
                tracing.AddSource(builder.Environment.ApplicationName)
                    .AddAspNetCoreInstrumentation(options =>
                        // Exclude health check requests from tracing
                        options.Filter = context =>
                            !context.Request.Path.StartsWithSegments(HealthEndpointPath)
                            && !context.Request.Path.StartsWithSegments(AlivenessEndpointPath)
                    )
                    // Uncomment the following line to enable gRPC instrumentation (requires the OpenTelemetry.Instrumentation.GrpcNetClient package)
                    //.AddGrpcClientInstrumentation()
                    .AddHttpClientInstrumentation();
            });

        #endregion


        // Add latency console data exporter
        builder.Services.AddConsoleLatencyDataExporter();

        builder.AddOpenTelemetryExporters();

        return builder;
    }

    private static TBuilder AddOpenTelemetryExporters<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        var useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

        if (useOtlpExporter)
        {
            builder.Services.AddOpenTelemetry().UseOtlpExporter();
        }

        // Uncomment the following lines to enable the Azure Monitor exporter (requires the Azure.Monitor.OpenTelemetry.AspNetCore package)
        //if (!string.IsNullOrEmpty(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]))
        //{
        //    builder.Services.AddOpenTelemetry()
        //       .UseAzureMonitor();
        //}

        return builder;
    }

    public static TBuilder AddDefaultHealthChecks<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        builder.Services.AddHealthChecks()
            // Add a default liveness check to ensure app is responsive
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        return builder;
    }

    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        // Adding health checks endpoints to applications in non-development environments has security implications.
        // See https://aka.ms/dotnet/aspire/healthchecks for details before enabling these endpoints in non-development environments.
        if (!app.Environment.IsDevelopment()) return app;

        // All health checks must pass for app to be considered ready to accept traffic after starting
        app.MapHealthChecks(HealthEndpointPath);

        // Only health checks tagged with the "live" tag must pass for app to be considered alive
        app.MapHealthChecks(AlivenessEndpointPath, new HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains("live")
        });

        return app;
    }
}