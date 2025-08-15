using Eventing.Data;

namespace Eventing.ApiService.Setup.DbContext;

public static class DbContextExtension
{
    public static void AddXDbContext(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<EventingDbContext>(
            connectionName: "eventing-db",
            configureSettings: settings =>
            {
                settings.ConnectionString += ";Include Error Detail=true";
            },
            configureDbContextOptions: options =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    options.EnableDetailedErrors()
                        .EnableSensitiveDataLogging();
                }
            });
    }
}