using Eventing.Data.Enums;

namespace Eventing.ApiService.Controllers.Event.Dto;

public record EventResponseDto(
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