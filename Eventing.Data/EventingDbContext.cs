using Eventing.Data.Entities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TickerQ.EntityFrameworkCore.Configurations;

namespace Eventing.Data;

public class EventingDbContext(DbContextOptions<EventingDbContext> options)
    : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>(options), IDataProtectionKeyContext
{
    public DbSet<Profile> Profiles { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Attendee> Attendees { get; set; }

    public DbSet<DataProtectionKey> DataProtectionKeys { get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply TickerQ entity configurations explicitly
        // Default Schema is "ticker".
        builder.ApplyConfiguration(new TimeTickerConfigurations());
        builder.ApplyConfiguration(new CronTickerConfigurations());
        builder.ApplyConfiguration(new CronTickerOccurrenceConfigurations());
    }
}