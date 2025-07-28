using Eventing.ApiService.Controllers.Event.Dto;
using Eventing.ApiService.Data;
using Eventing.ApiService.Services.CurrentUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Controllers.Event;

[Authorize]
public class EventsController(EventingDbContext dbContext, CurrentUserService currentUserService) : ApiBaseController
{
    [HttpGet]
    [ProducesDefaultResponseType]
    [ProducesResponseType<IEnumerable<EventResponseDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EventResponseDto>>> GetAllAsync([FromQuery] string? search,
        CancellationToken ct)
    {
        var events = await dbContext.Events
            .Where(x => search == null || x.Title.ToLower() == search.ToLower())
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new EventResponseDto(x.Id, x.Title, x.Description, x.StartTime, x.EndTime,
                x.LocationType, x.Location, x.CreatedBy, x.CreatedAt, x.UpdatedAt))
            .ToListAsync(ct);

        return Ok(events);
    }

    [HttpGet("{eventId:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventResponseDto>> GetByIdAsync([FromRoute] Guid eventId, CancellationToken ct)
    {
        if (!await EventExistsAsync(eventId, ct)) return NotFound();

        var @event = await dbContext.Events
            .Where(x => x.Id == eventId)
            .Select(x => new EventResponseDto(
                x.Id,
                x.Title,
                x.Description,
                x.StartTime,
                x.EndTime,
                x.LocationType,
                x.Location,
                x.CreatedBy,
                x.CreatedAt,
                x.UpdatedAt))
            .FirstOrDefaultAsync(ct);

        if (@event is null) return NotFound();

        return Ok(@event);
    }

    [HttpPost]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<HttpValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EventResponseDto>> CreateAsync([FromBody] CreateEventRequestDto dto,
        CancellationToken ct)
    {
        var @event = new Data.Entities.Event
        {
            Title = dto.Title,
            Description = dto.Description,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            LocationType = dto.LocationType,
            Location = dto.Location,
            ShowAttendees = dto.ShowAttendees,
            CreatedBy = currentUserService.UserId
        };

        dbContext.Events.Add(@event);

        await dbContext.SaveChangesAsync(ct);

        var response = new EventResponseDto(@event.Id, @event.Title, @event.Description, @event.StartTime,
            @event.EndTime, @event.LocationType, @event.Location, @event.CreatedBy, @event.CreatedAt, @event.UpdatedAt);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = @event.Id }, response);
    }

    [HttpPut("{eventId:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<HttpValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid eventId, [FromBody] UpdateEventRequestDto dto,
        CancellationToken ct)
    {
        var @event = await dbContext.Events.FirstOrDefaultAsync(x => x.Id == eventId, ct);
        if (@event is null) return NotFound();
        if (@event.CreatedBy != currentUserService.UserId) return Forbid();

        @event.Title = dto.Title;
        @event.Description = dto.Description;
        @event.StartTime = dto.StartTime;
        @event.EndTime = dto.EndTime;
        @event.LocationType = dto.LocationType;
        @event.Location = dto.Location;
        @event.ShowAttendees = dto.ShowAttendees;
        @event.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(ct);

        return NoContent();
    }

    [HttpDelete("{eventId:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid eventId, CancellationToken ct)
    {
        var @event = await dbContext.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == eventId, ct);
        if (@event is null) return NotFound();
        if (@event.CreatedBy != currentUserService.UserId) return Forbid();

        dbContext.Remove(@event);
        await dbContext.SaveChangesAsync(ct);

        return Ok();
    }

    [HttpGet("{eventId:guid}/attendees")]
    [ProducesResponseType<IEnumerable<AttendeeResponseDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IEnumerable<AttendeeResponseDto>>> GetAllEventAttendeesAsync(
        [FromRoute] Guid eventId,
        CancellationToken ct)
    {
        if (!await EventExistsAsync(eventId, ct)) return NotFound();
        if (!await IsCurrentUserAnAttendeeAsync(eventId, ct)) return Forbid();

        var attendees = await dbContext.Attendees
            .Include(x => x.Responder)
            .Where(a => a.EventId == eventId &&
                        (
                            a.Event.ShowAttendees
                            || a.Event.CreatedBy == currentUserService.UserId
                            || a.IsOrganizer
                            || a.ResponderId == currentUserService.UserId
                        ))
            .OrderByDescending(x => x.IsOrganizer)
            .ThenBy(x => x.Responder.Name)
            .Select(x => new AttendeeResponseDto(
                x.Id,
                x.RsvpResponse,
                x.IsOrganizer,
                x.Comment,
                x.RespondedAt,
                x.UpdatedAt,
                new AttendeeInfo(
                    x.Responder.Id,
                    x.Responder.Name)
            ))
            .ToListAsync(ct);

        return Ok(attendees);
    }

    [HttpPatch("{eventId:guid}/attendees/{attendeeId:guid}/rsvp")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateAttendeeRsvpResponseAsync([FromRoute] Guid eventId,
        [FromRoute] Guid attendeeId,
        [FromBody] PatchRsvpRequestDto dto, CancellationToken ct)
    {
        var attendee = await dbContext.Attendees
            .Where(x => x.Id == attendeeId && x.EventId == eventId)
            .FirstOrDefaultAsync(ct);

        if (attendee is null) return NotFound();
        if (attendee.ResponderId != currentUserService.UserId) return Forbid();

        attendee.RsvpResponse = dto.RsvpResponse;
        attendee.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(ct);

        return NoContent();
    }

    private Task<bool> EventExistsAsync(Guid eventId, CancellationToken ct) =>
        dbContext.Events.AnyAsync(e => e.Id == eventId, ct);

    private Task<bool> IsCurrentUserAnAttendeeAsync(Guid eventId, CancellationToken ct) =>
        dbContext.Attendees.AnyAsync(a =>
            a.EventId == eventId &&
            a.ResponderId == currentUserService.UserId, ct);
}