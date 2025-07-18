using System.ComponentModel.DataAnnotations.Schema;

namespace Eventing.ApiService.Data.Entities;

[Table("users")]
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }

    public ICollection<Attendee> EventParticipations { get; set; } = new List<Attendee>();
    public ICollection<Event> CreatedEvents { get; set; } = new List<Event>();
}