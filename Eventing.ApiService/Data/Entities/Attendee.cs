using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eventing.ApiService.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Data.Entities;

[Table("attendees")]
[Index(nameof(EventId))]
[Index(nameof(ResponderId))]
[Index(nameof(ResponderId), nameof(EventId), IsUnique = true)]
public sealed class Attendee
{
    public const int MinCommentsCharacters = 50;
    public const int MaxCommentsCharacters = 512;

    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EventId { get; set; }
    [ForeignKey(nameof(EventId))] public Event Event { get; set; } = null!;

    public Guid ResponderId { get; set; }
    [ForeignKey(nameof(ResponderId))] public Profile Responder { get; set; } = null!;

    public bool IsOrganizer { get; set; }

    public RsvpResponse RsvpResponse { get; set; } = RsvpResponse.Pending;

    public DateTime? RespondedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }

    [MinLength(MinCommentsCharacters)]
    [MaxLength(MaxCommentsCharacters)]
    public string? Comment { get; set; }
}