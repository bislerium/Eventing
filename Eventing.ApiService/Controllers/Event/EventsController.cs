using Eventing.ApiService.Controllers.Event.Dto;
using Eventing.ApiService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Controllers.Event;

public class EventsController(EventingDbContext dbContext) : ApiBaseController
{
    [HttpGet]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<List<EventResponseDto>> GetAllAsync([FromQuery] string? search, CancellationToken ct)
        => dbContext.Events.Where(x => search == null || x.Title.ToLower() == search.ToLower())
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new EventResponseDto(x.Id, x.Title, x.Description, x.StartTime, x.EndTime,
                x.LocationType, x.Location, x.CreatedBy, x.CreatedAt, x.UpdatedAt)).ToListAsync(ct);

    [HttpGet("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventResponseDto>> GetByIdAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var @event = await dbContext.Events
            .Where(x => x.Id == id)
            .Select(x => new EventResponseDto(x.Id, x.Title, x.Description, x.StartTime, x.EndTime,
                x.LocationType, x.Location, x.CreatedBy, x.CreatedAt, x.UpdatedAt))
            .FirstOrDefaultAsync(ct);
        
        if (@event is null) return NotFound();
        
        return Ok(@event);
    }

    [HttpPost]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EventResponseDto>> CreateAsync([FromBody] CreateEventRequestDto dto, CancellationToken ct)
    {
        var @event = new Data.Entities.Event
        {
            Title = dto.Title,
            Description = dto.Description,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            LocationType = dto.LocationType,
            Location = dto.Location,
            CreatedBy = dto.CreatedBy
        };

        dbContext.Events.Add(@event);

        await dbContext.SaveChangesAsync(ct);
        
        var response = new EventResponseDto(@event.Id, @event.Title, @event.Description, @event.StartTime, @event.EndTime, @event.LocationType, @event.Location,@event.CreatedBy, @event.CreatedAt, @event.UpdatedAt);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = @event.Id }, response);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateEventRequestDto dto, CancellationToken ct)
    {
        var @event = await dbContext.Events.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (@event is null) return NotFound();
        
        @event.Title = dto.Title;
        @event.Description = dto.Description;
        @event.StartTime = dto.StartTime;
        @event.EndTime = dto.EndTime;
        @event.LocationType = dto.LocationType;
        @event.Location = dto.Location;
        @event.UpdatedAt = DateTime.UtcNow;
        
        await dbContext.SaveChangesAsync(ct);

        return NoContent();
    } 

    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var @event = await dbContext.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
        if (@event is null) return NotFound();
        
        dbContext.Remove(@event);
        await dbContext.SaveChangesAsync(ct);
        
        return Ok();
    }
}