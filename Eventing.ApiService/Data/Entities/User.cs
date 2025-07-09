using System.ComponentModel.DataAnnotations.Schema;

namespace Eventing.ApiService.Data.Entities;

[Table("users")]
public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    
    public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
    public ICollection<Event> Events { get; set; } = new List<Event>();

    // Other properties
}