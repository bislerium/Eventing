// <copyright file="DataProtectionExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Eventing.Data;
using Microsoft.AspNetCore.DataProtection;

namespace Eventing.ApiService.Setup.DataProtection;

public static class DataProtectionExtension
{
    public static IServiceCollection AddXDataProtection(this IServiceCollection services)
    {
        services.AddDataProtection()
            .SetApplicationName(nameof(Eventing))
            .SetDefaultKeyLifetime(TimeSpan.FromDays(60))
            .PersistKeysToDbContext<EventingDbContext>();

        return services;
    }
}