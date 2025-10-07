using Aspire.Hosting.DevTunnels;
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

builder.AddDevTunnel(
        name: "web-app-tunnel",
        tunnelId: "web-app-tunnel-shared",
        options: new DevTunnelOptions
        {
            AllowAnonymous = true,
            Description = "Shared web-application tunnel",
            Labels = ["eventing", "web-app"],
        })
    .WithReference(webFrontend)
    .WithExplicitStart();

builder.AddDevTunnel(
        name: "web-api-tunnel",
        tunnelId: "web-api-tunnel-shared",
        options: new DevTunnelOptions
        {
            AllowAnonymous = true,
            Description = "Shared web-api tunnel",
            Labels = ["eventing", "web-api"],
        })
    .WithReference(apiService)
    .WithExplicitStart();

await builder.Build().RunAsync();