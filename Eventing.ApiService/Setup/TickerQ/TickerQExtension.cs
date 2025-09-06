// <copyright file="TickerQExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Eventing.Data;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DependencyInjection;

namespace Eventing.ApiService.Setup.TickerQ;

public static class TickerQExtension
{
    public static IServiceCollection AddXTickerQ(this IServiceCollection services)
    {
        services.AddTickerQ(options =>
        {
            options.SetMaxConcurrency(10);

            // Set fallback time out to check for missed jobs and execute.
            options.UpdateMissedJobCheckDelay(TimeSpan.FromSeconds(30));

            // Configure the EF Core–backed operational store for TickerQ metadata, locks, and state.
            options.AddOperationalStore<EventingDbContext>(efOpt =>
            {
                // On app start, cancel tickers left in Expired or InProgress (terminated) states
                // to prevent duplicate re-execution after crashes or abrupt shutdowns.
                efOpt.CancelMissedTickersOnAppStart();

                // Defined cron-based functions are auto-seeded in the database by default.
                // Example: [TickerFunction(..., "*/5 * * * *")]
                // Use this to ignore them and keep seeds runtime-only.
                efOpt.IgnoreSeedMemoryCronTickers();
            });
            options.AddDashboard(uiOpt =>
            {
                // Mount path for the dashboard UI (default: "/tickerq-dashboard").
                uiOpt.BasePath = "/tickerq-dashboard";

                // Basic auth toggle (default: false).
                uiOpt.EnableBasicAuth = true;
            });
        });

        return services;
    }
}