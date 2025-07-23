using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Eventing.ApiService.Data.Entities;

[Table("users")]
public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    
    public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
    public ICollection<Event> Events { get; set; } = new List<Event>();

    // Other properties
}