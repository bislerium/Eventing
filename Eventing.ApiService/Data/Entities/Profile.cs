using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Eventing.ApiService.Data.Entities;

[Table("profiles")]
public sealed class Profile
{
    public const int MaxNameCharacters = 256;
    
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey(nameof(Id))] public IdentityUser<Guid> User { get; set; } = null!;

    [StringLength(MaxNameCharacters)] public string Name { get; set; } = null!;

    public ICollection<Attendee> AttendedEvents { get; set; } = [];
    public ICollection<Event> CreatedEvents { get; set; } = [];
}