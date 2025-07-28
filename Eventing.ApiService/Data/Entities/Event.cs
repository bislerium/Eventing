using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eventing.ApiService.Data.Enums;

namespace Eventing.ApiService.Data.Entities;

[Table("events")]
public sealed class Event
{
    public const int MaxTitleCharacters = 100;
    public const int MaxDescriptionCharacters = 1024;
    public const int MaxLocationCharacters = 256;

    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(MaxTitleCharacters)] public string Title { get; set; } = null!;

    [MaxLength(MaxDescriptionCharacters)] public string? Description { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public LocationType LocationType { get; set; }

    [MaxLength(MaxLocationCharacters)] public string Location { get; set; } = null!;

    public bool ShowAttendees { get; set; }

    public Guid CreatedBy { get; set; }
    [ForeignKey(nameof(CreatedBy))] public Profile Creator { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
}