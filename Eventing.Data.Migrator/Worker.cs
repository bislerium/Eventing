using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Eventing.Data.Migrator;

public class Worker(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime,
    ILogger<Worker> logger
) : BackgroundService
{
    public const string ActivitySourceName = "Migrations";
    private static readonly ActivitySource SActivitySource = new(ActivitySourceName);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var activity = SActivitySource.StartActivity(ActivityKind.Client);
        logger.LogInformation("Migrator running at: {time}", DateTimeOffset.UtcNow);
        var startTimestamp = Stopwatch.GetTimestamp();
        try
        {
            await using var scope = serviceProvider.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<EventingDbContext>();
            await dbContext.Database.MigrateAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
            logger.LogError(ex, "Migrator Failed to complete.");
            throw;
        }

        var elapsedMilliseconds = Stopwatch.GetElapsedTime(startTimestamp).Milliseconds;
        logger.LogInformation("Migrator took {elapsedMilliseconds} milliseconds to complete.", elapsedMilliseconds);

        hostApplicationLifetime.StopApplication();
    }
}