using Eventing.Web.Components.Features.Event.Enums;

namespace Eventing.Web.Components.Features.Event.Dtos;

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
    DateTime? UpdatedAt
);

public sealed record Creator(Guid Id, string Name);