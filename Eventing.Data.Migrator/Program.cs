using Eventing.Data;
using Eventing.Data.Migrator;
using Eventing.ServiceDefaults;
using Microsoft.AspNetCore.Identity;

var builder = Host.CreateApplicationBuilder(args);

builder.ConfigureOpenTelemetry();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName))
    .WithMetrics(x => x.AddMeter("Microsoft.EntityFrameworkCore"));

builder.Services.AddHostedService<Worker>();

builder.Services.AddIdentityCore<IdentityUser<Guid>>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<EventingDbContext>();

builder.AddNpgsqlDbContext<EventingDbContext>("eventing-db",
    configureSettings: settings => { settings.ConnectionString += ";Include Error Detail=true"; });

var host = builder.Build();
host.Run();