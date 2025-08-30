using Eventing.Web.Ui.Features.Event.Enums;

namespace Eventing.Web.Ui.Features.Event.Page.Dtos;

public sealed record EventResponseDto(
    Guid Id,
    string Title,
    string? Description,
    DateTime StartTime,
    DateTime EndTime,
    LocationType LocationType,
    string Location,
    bool ShowAttendees,
    Creator CreatedBy,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    int TotalAttendees
);

public sealed record Creator(Guid Id, string Name);