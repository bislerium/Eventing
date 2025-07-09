using Eventing.ApiService.Data.Enums;

namespace Eventing.ApiService.Controllers.Event.Dto;

public record EventResponseDto(
    Guid Id,
    string Title,
    string? Description,
    DateTime StartTime,
    DateTime EndTime,
    LocationType LocationType,
    string Location,
    Guid CreatedBy,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);