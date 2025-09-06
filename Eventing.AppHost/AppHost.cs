using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddDbGate("db-gate");

var cache = builder.AddRedis("cache")
    .WithDbGate();

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithDbGate();

var eventingDb = postgres.AddDatabase("eventing-db");

var mailPit = builder.AddMailPit("mail-pit");

builder.AddProject<Projects.Eventing_Data_Migrator>("data-migrator")
    .WithReference(eventingDb)
    .WaitFor(eventingDb)
    .WithExplicitStart();

var apiService = builder.AddProject<Projects.Eventing_ApiService>("api-service")
    .WithHttpHealthCheck("/health")
    .WaitFor(eventingDb)
    .WithReference(eventingDb)
    .WaitFor(cache)
    .WithReference(cache)
    .WithReference(mailPit)
    .WaitFor(mailPit);

// See: https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/custom-resource-urls#customize-endpoint-url
apiService.WithUrlForEndpoint(
    "https",
    _ => new ResourceUrlAnnotation { Url = "/tickerq-dashboard", DisplayText = "TickerQ (HTTPS)" });

if (builder.Environment.IsDevelopment())
{
    // See: https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/custom-resource-urls#customize-endpoint-url
    apiService.WithUrlForEndpoint(
        "https",
        _ => new ResourceUrlAnnotation { Url = "/api-reference", DisplayText = "Scalar (HTTPS)" });
}

var webFrontend = builder.AddProject<Projects.Eventing_Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

// See:
// https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows#secret-manager
// https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/external-parameters
// For Ngrok AuthToken, Goto https://dashboard.ngrok.com/get-started/your-authtoken
var ngrokAuthToken = builder.AddParameter("NgrokAuthToken", secret: true);
builder.AddNgrok("ngrok")
    .WithAuthToken(ngrokAuthToken)
    .WithTunnelEndpoint(apiService, "https")
    .WithTunnelEndpoint(webFrontend, "https")
    .WaitFor(apiService)
    .WaitFor(webFrontend)
    .WithExplicitStart();

await builder.Build().RunAsync();