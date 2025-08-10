using Eventing.ApiService.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Eventing.ApiService.Data.Seeders;

public static class UserSeeder
{
    public static async Task SeedAsync(DbContext dbContext, CancellationToken cancellationToken)
    {
        const string defaultPassword = "Temp@12345";

        var logger = dbContext.GetService<ILoggerFactory>().CreateLogger(nameof(UserSeeder));
        var userManager = dbContext.GetService<UserManager<IdentityUser<Guid>>>();
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

        logger.LogInformation("Seeding users (Identity User + Profile).");
        
        // 2. Create users + profiles
        foreach (var (id, email, role, _) in usersToCreate)
        {
            var isExistingUser = await dbContext.Set<IdentityUser<Guid>>().AnyAsync(x => x.Id == id, cancellationToken);
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
                logger.LogError(
                    "Identity user creation failed. UserId: {UserId}, Errors: {@IdentityErrors}",
                    id,
                    result.Errors
                );

                throw new InvalidOperationException(
                    $"Failed to create identity user '{id}'. See logs for details."
                );
            }

            await userManager.AddToRoleAsync(user, role);
        }

        foreach (var (id, _, _, name) in usersToCreate)
        {
            var isExistingProfile = await dbContext.Set<Profile>().AnyAsync(x => x.Id == id, cancellationToken);
            if (isExistingProfile) continue;
            
            profiles.Add(new Profile
            {
                Id = id,
                Name = name
            });
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}