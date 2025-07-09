using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eventing.ApiService.Data.Enums;

namespace Eventing.ApiService.Data.Entities;

[Table("events")]
public class Event
{
    private const int MaxTitleCharacters = 100;
    private const int MaxDescriptionCharacters = 1024;
    private const int MaxLocationCharacters = 256;
    
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [MaxLength(MaxTitleCharacters)]
    public required string Title { get; set; }

    [MaxLength(MaxDescriptionCharacters)] public string? Description { get; set; }

    [Required] public DateTime StartTime { get; set; }

    [Required] public DateTime EndTime { get; set; }

    [Required] public required LocationType LocationType { get; set; }

    [Required]
    [MaxLength(MaxLocationCharacters)]
    public required string Location { get; set; }

    public Guid CreatedBy { get; set; }
    [ForeignKey(nameof(CreatedBy))] public User Creator { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
}