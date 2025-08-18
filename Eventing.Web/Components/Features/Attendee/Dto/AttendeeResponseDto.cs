using Eventing.Web.Components.Features.Attendee.Enum;

namespace Eventing.Web.Components.Features.Attendee.Dto;

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