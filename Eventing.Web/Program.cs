using System.Net;
using Eventing.ServiceDefaults;
using Eventing.Web;
using Eventing.Web.Components;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Options;
using Microsoft.FluentUI.AspNetCore.Components;
using Polly;
using Polly.Fallback;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluentUIComponents();

builder.Services.AddHttpClient(
    name: Constants.HttpClients.EventingApi.Name,
    configureClient: client =>
    {
        // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
        // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
        client.BaseAddress = new Uri("https+http://apiservice");
        client.Timeout = Timeout.InfiniteTimeSpan;
    })
    .AddResilienceHandler("standard", (builder1, context) =>
    {
        var options = new HttpStandardResilienceOptions();
        
        var loggerFactory = context.ServiceProvider.GetRequiredService<ILoggerFactory>();
        builder1.AddFallback(new FallbackStrategyOptions<HttpResponseMessage>
            {
                FallbackAction = _ =>
                    Outcome.FromResultAsValueTask(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable))
            })
            .AddRateLimiter(options.RateLimiter)
            .AddTimeout(options.TotalRequestTimeout)
            .AddRetry(options.Retry)
            .AddCircuitBreaker(options.CircuitBreaker)
            .AddTimeout(options.AttemptTimeout)
            .ConfigureTelemetry(loggerFactory)
            .Build();
    });

var app = builder.Build();

app.UseHttpLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();