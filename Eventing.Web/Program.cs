using System.Net;
using Eventing.ServiceDefaults;
using Eventing.Web;
using Eventing.Web.Components;
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

builder.Services.AddScoped<HttpToastErrorHandler>();

builder.Services.AddHttpClient(
        name: Constants.HttpClients.EventingApi.Name,
        configureClient: client =>
        {
            // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
            // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
            client.BaseAddress = new Uri("https+http://apiservice");
        })
    .AddHttpMessageHandler<HttpToastErrorHandler>()
    .AddResilienceHandler("standard", builder1 =>
    {
        builder1.AddFallback(new FallbackStrategyOptions<HttpResponseMessage>
        {
            ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                .HandleResult(x => !x.IsSuccessStatusCode)
                .Handle<HttpRequestException>(),
    
            FallbackAction = _ =>
            {
                if (_.Outcome.Exception is null)
                {
                    var response = _.Outcome.Result;
                    response.Headers.Add(Constants.CustomHeaders.FallBackHeader, "true");
                    return Outcome.FromResultAsValueTask(response);
                }
                else
                    return Outcome.FromResultAsValueTask(
                        new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                        {
                            ReasonPhrase = "Fallback",
                            Headers = { { Constants.CustomHeaders.FallBackHeader, "true" } }
                        });
            }
        });
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