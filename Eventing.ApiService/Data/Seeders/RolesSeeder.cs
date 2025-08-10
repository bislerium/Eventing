using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Eventing.ApiService.Data.Seeders;

public static class RolesSeeder
{
    public static async Task SeedAsync(DbContext dbContext, CancellationToken cancellationToken)
    {
        using var scope = dbContext.GetService<IServiceScopeFactory>().CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

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