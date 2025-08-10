using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Seeders;

namespace Eventing.ApiService.Setup.DbContext;

public static class DbContextExtension
{
    public static void AddXDbContextExtension(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<EventingDbContext>(connectionName: "eventing-db",
            configureSettings: settings =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    settings.ConnectionString += ";Include Error Detail=true";
                }
            },
            configureDbContextOptions: options =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    options.EnableDetailedErrors()
                        .EnableSensitiveDataLogging();
                }

                options.UseAsyncSeeding(async (context, _, ct) =>
                {
                    await RolesSeeder.SeedAsync(context, ct);
                    await UserSeeder.SeedAsync(context, ct);
                    await EventSeeder.SeedAsync(context, ct);
                });
            });
    }
}