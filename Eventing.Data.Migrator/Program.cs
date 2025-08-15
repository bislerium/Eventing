using Eventing.Data;
using Eventing.Data.Migrator;
using Eventing.Data.Seeders;
using Eventing.ServiceDefaults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddServiceDiscovery();

builder.AddServiceDefaults();


builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName))
    .WithMetrics(x => x.AddMeter("Microsoft.EntityFrameworkCore"));

builder.Services.AddHostedService<Worker>();

builder.Services.AddIdentityCore<IdentityUser<Guid>>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<EventingDbContext>();

builder.Services.AddDbContextPool<EventingDbContext>((serviceProvider, dbContextOptionsBuilder) =>
{
    var connectionString = builder.Configuration.GetConnectionString("eventing-db");
    if (builder.Environment.IsDevelopment())
    {
        connectionString += ";Include Error Detail=true";
    }

    dbContextOptionsBuilder.UseNpgsql(connectionString);

    if (builder.Environment.IsDevelopment())
    {
        dbContextOptionsBuilder.EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    }

    dbContextOptionsBuilder.UseAsyncSeeding(async (context, _, _) =>
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var scopedServiceProvider = scope.ServiceProvider;

        await RolesSeeder.SeedAsync(scopedServiceProvider, context);
        await UserSeeder.SeedAsync(scopedServiceProvider, context);
        await EventSeeder.SeedAsync(context);
    });
});

builder.EnrichNpgsqlDbContext<EventingDbContext>();

var host = builder.Build();
host.Run();