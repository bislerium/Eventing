using Eventing.ApiService.Data.Enums;

namespace Eventing.ApiService.Controllers.Event.Dto;

public sealed record AttendeeResponseDto(
    Guid AttendeeId,
    RsvpResponse Response,
    bool IsOrganizer,
    string? Comment,
    DateTime? RespondedAt,
    DateTime? UpdatedAt,
    AttendeeInfo Responder
);

public sealed record AttendeeInfo(
    Guid UserId,
    string Name
);