using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eventing.ApiService.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Data.Entities;

[Table("attendees")]
[Index(nameof(EventId))]
public class Attendee
{
    public const int MinCommentsCharacters = 50;
    public const int MaxCommentsCharacters = 512;

    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EventId { get; set; }
    [ForeignKey(nameof(EventId))] public Event Event { get; set; } = null!;

    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; } = null!;

    public bool IsOrganizer { get; set; } = false;

    public RsvpResponse RsvpResponse { get; set; } = RsvpResponse.Pending;

    public DateTime? RespondedAt { get; set; }

    [MinLength(MinCommentsCharacters)]
    [MaxLength(MaxCommentsCharacters)]
    public string? Comments { get; set; }
}