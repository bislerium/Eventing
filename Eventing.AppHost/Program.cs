var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var db = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithPgWeb()
    .AddDatabase("eventing-db");

var apiService = builder.AddProject<Projects.Eventing_ApiService>("apiservice")
    .WaitFor(db)
    .WithReference(db);



builder.AddProject<Projects.Eventing_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();