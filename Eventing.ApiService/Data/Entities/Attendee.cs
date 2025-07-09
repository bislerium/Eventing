using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eventing.ApiService.Data.Enums;

namespace Eventing.ApiService.Data.Entities;

[Table("attendees")]
public class Attendee
{
    public Guid Id { get; set; }
    
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public RsvpResponse Response { get; set; } = RsvpResponse.Pending;
    public DateTime RespondedAt { get; set; }
    
    public bool IsOrganizer { get; set; }
    
    [MaxLength(500)]
    public string? Comment { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}