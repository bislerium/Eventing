using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventing.ApiService.Data.Entities;

[Table("events")]
public class Event
{
    [Key] public Guid Id { get; set; }

    [MaxLength(120)] // varchar(120)
    public string Title { get; set; }
    
    [MaxLength(500)] public string? Description { get; set; }

    [MaxLength(256)] public string Location { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Guid CreatedBy { get; set; }

    [ForeignKey(nameof(CreatedBy))] public User Creator { get; set; } //Navigation property

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}