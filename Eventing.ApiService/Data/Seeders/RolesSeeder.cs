using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Eventing.ApiService.Data.Seeders;

public static class RolesSeeder
{
    public static async Task SeedAsync(DbContext dbContext, CancellationToken cancellationToken)
    {
        var roleManager = dbContext.GetService<RoleManager<IdentityRole<Guid>>>();
        var logger = dbContext.GetService<ILoggerFactory>().CreateLogger(nameof(RolesSeeder));
        
        logger.LogInformation("Seeding users (Identity User + Profile).");
        var roles = new[] { "General", "Admin" };

        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
            }
        }
    }
}