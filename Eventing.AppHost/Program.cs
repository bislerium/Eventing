var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithRedisCommander();

var db = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithPgAdmin()
    .AddDatabase("eventing-db");

var mailPit = builder.AddMailPit("mailpit");

var apiService = builder.AddProject<Projects.Eventing_ApiService>("apiservice")
    .WaitFor(db)
    .WithReference(db)
    .WaitFor(cache)
    .WithReference(cache)
    .WithReference(mailPit)
    .WaitFor(mailPit);

builder.AddProject<Projects.Eventing_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();