using Eventing.Web.Ui.Features.Event.Enums;

namespace Eventing.Web.Ui.Features.Event.Toolbar.CreateEvent.Dialog.Dtos;

public sealed record CreateEventRequestDto(
    string Title,
    string? Description,
    DateTime StartTime,
    DateTime EndTime,
    LocationType LocationType,
    string Location,
    bool ShowAttendees);