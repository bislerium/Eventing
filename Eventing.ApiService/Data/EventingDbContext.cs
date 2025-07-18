using Eventing.ApiService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Data;

public class EventingDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}