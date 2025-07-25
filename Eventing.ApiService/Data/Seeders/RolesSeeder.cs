using Microsoft.AspNetCore.Identity;

namespace Eventing.ApiService.Data.Seeders;

public class RolesSeeder(RoleManager<IdentityRole> roleManager)
{
    public async Task SeedAsync()
    {
        await roleManager.CreateAsync(new IdentityRole("General"));
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
}