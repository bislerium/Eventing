using Eventing.ApiService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Data.Seeders;

public static class UserSeeder
{
    public static async Task SeedAsync(DbContext dbContext, CancellationToken cancellationToken)
    {
        /*// Define users to seed
        var usersToSeed = new List<Profile>
        {
            new()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Alice Smith",
                Email = "alice@example.com", Address = "123 Main St"
            },
            new()
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Bob Johnson",
                Email = "bob@example.com", Address = "456 Elm St"
            },
            new()
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Carol Lee",
                Email = "carol@example.com", Address = "789 Oak Ave"
            },
            new()
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "David King",
                Email = "david@example.com", Address = "321 Pine Rd"
            },
            new()
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Eve Martin", Email = "eve@example.com",
                Address = "654 Maple St"
            }
        };

        // Get IDs of existing users to avoid duplication
        var existingUserIds = await dbContext.Set<Profile>()
            .Where(u => usersToSeed.Select(x => x.Id).Contains(u.Id))
            .Select(u => u.Id)
            .ToListAsync(cancellationToken);

        // Filter users that are not already in database
        var newUsers = usersToSeed.ExceptBy(existingUserIds, x => x.Id).ToArray();

        if (newUsers.Length > 0)
        {
            await dbContext.Set<Profile>().AddRangeAsync(newUsers, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }*/
    }
}