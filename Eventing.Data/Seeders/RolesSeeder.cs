using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eventing.Data.Seeders;

public static class RolesSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider, DbContext dbContext)
    {
        var roleStore = ActivatorUtilities.CreateInstance<RoleStore<IdentityRole<Guid>, DbContext, Guid>>(
            serviceProvider,
            dbContext // explicitly use the DbContext from UseAsyncSeeding
        );

        var roleManager = ActivatorUtilities.CreateInstance<RoleManager<IdentityRole<Guid>>>(
            serviceProvider,
            roleStore
        );

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