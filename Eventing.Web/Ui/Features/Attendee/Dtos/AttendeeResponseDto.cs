using Eventing.Web.Ui.Features.Attendee.Enums;

namespace Eventing.Web.Ui.Features.Attendee.Dtos;

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