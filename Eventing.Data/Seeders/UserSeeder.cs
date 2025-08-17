using Eventing.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eventing.Data.Seeders;

public static class UserSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider, DbContext dbContext)
    {
        const string defaultPassword = "Temp@12345";

        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>();

        var profiles = dbContext.Set<Profile>();

        var usersToCreate = new List<(Guid Id, string Email, string Role, string Name)>
        {
            // Admin
            (Guid.Parse("00000000-0000-0000-0000-000000000001"), "admin@example.com", "Admin", "System Administrator"),

            // General users
            (Guid.Parse("00000000-0000-0000-0000-000000000002"), "alice@example.com", "General", "Alice Johnson"),
            (Guid.Parse("00000000-0000-0000-0000-000000000003"), "bob@example.com", "General", "Bob Smith"),
            (Guid.Parse("00000000-0000-0000-0000-000000000004"), "carol@example.com", "General", "Carol Davis"),
            (Guid.Parse("00000000-0000-0000-0000-000000000005"), "david@example.com", "General", "David Miller"),
            (Guid.Parse("00000000-0000-0000-0000-000000000006"), "eve@example.com", "General", "Eve Brown"),
            (Guid.Parse("00000000-0000-0000-0000-000000000007"), "frank@example.com", "General", "Frank Wilson"),
            (Guid.Parse("00000000-0000-0000-0000-000000000008"), "grace@example.com", "General", "Grace Taylor"),
            (Guid.Parse("00000000-0000-0000-0000-000000000009"), "henry@example.com", "General", "Henry Anderson"),
            (Guid.Parse("00000000-0000-0000-0000-000000000010"), "irene@example.com", "General", "Irene Thomas"),
        };

        // 2. Create users + profiles
        foreach (var (id, email, role, name) in usersToCreate)
        {
            var isExistingUser = await dbContext.Set<IdentityUser<Guid>>().AnyAsync(x => x.Id == id);
            if (isExistingUser) continue;

            var user = new IdentityUser<Guid>
            {
                Id = id,
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, defaultPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
                throw new InvalidOperationException(
                    $"Failed to create identity user '{id}'. Errors: {errors}"
                );
            }

            await userManager.AddToRoleAsync(user, role);
            
            profiles.Add(new Profile
            {
                Id = id,
                Name = name
            });
        }

        await dbContext.SaveChangesAsync();
    }
}