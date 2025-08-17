using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithRedisCommander();

var eventingDb = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithPgAdmin(configure
        => configure.WithImageTag("latest"))
    .AddDatabase("eventing-db");

var mailPit = builder.AddMailPit("mailpit");

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

if (builder.Environment.IsDevelopment())
{
    // See: https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/custom-resource-urls#customize-endpoint-url
    apiService.WithUrlForEndpoint("https", _ => new ResourceUrlAnnotation
    {
        Url = "/api-reference",
        DisplayText = "Scalar (HTTPS)"
    });
}

builder.AddProject<Projects.Eventing_Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();