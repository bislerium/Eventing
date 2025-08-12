using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Setup.DbContext;

public static class DbContextExtension
{
    public static void AddXDbContextExtension(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContextPool<EventingDbContext>((serviceProvider, dbContextOptionsBuilder) =>
        {
            var connectionString = builder.Configuration.GetConnectionString("eventing-db");
            if (builder.Environment.IsDevelopment())
            {
                connectionString += ";Include Error Detail=true";
            }

            dbContextOptionsBuilder.UseNpgsql(connectionString,
                npgsqlDbContextOptionsBuilder => { npgsqlDbContextOptionsBuilder.EnableRetryOnFailure(); });

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
    }
}