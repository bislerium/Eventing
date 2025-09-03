using Eventing.Web.Ui.Features.Event.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Eventing.Web.Ui.Features.Event.Toolbar.CreateEvent.Dialog.Models;

public class CreateEventModel
{
    [Required] public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required] public DateTime? StartDate { get; set; } = DateTime.Today;

    [Required] public TimeSpan? StartTime { get; set; } = DateTime.Now.TimeOfDay;

    [Required] public DateTime? EndDate { get; set; } = DateTime.Today;

    [Required] public TimeSpan? EndTime { get; set; } = DateTime.Now.AddHours(1).TimeOfDay;

    public LocationType LocationType { get; set; }

    [Required] public string Location { get; set; }

    public bool ShowAttendees { get; set; } = true;
}