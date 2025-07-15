using Eventing.ApiService.Controllers.Event.Dto;
using Eventing.ApiService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Controllers.Event;

[ApiConventionType(typeof(DefaultApiConventions))]
public class EventsController(EventingDbContext dbContext) : ApiBaseController
{
    [HttpGet]
    public Task<List<EventResponseDto>> GetAllAsync([FromQuery] string? search)
        => dbContext.Events.Where(x => search == null || x.Title.ToLower() == search.ToLower())
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new EventResponseDto(x.Id, x.Title, x.Description, x.StartTime, x.EndTime,
                x.LocationType, x.Location, x.CreatedBy, x.CreatedAt, x.UpdatedAt))
            .ToListAsync(HttpContext.RequestAborted);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EventResponseDto>> GetByIdAsync([FromRoute] Guid id)
    {
        var @event = await dbContext.Events
            .Where(x => x.Id == id)
            .Select(x => new EventResponseDto(x.Id, x.Title, x.Description, x.StartTime, x.EndTime,
                x.LocationType, x.Location, x.CreatedBy, x.CreatedAt, x.UpdatedAt))
            .FirstOrDefaultAsync(HttpContext.RequestAborted);
        
        if (@event is null) return NotFound();
        
        return Ok(@event);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEventRequestDto dto)
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

        await dbContext.SaveChangesAsync(HttpContext.RequestAborted);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = @event.Id }, null);
    }
    
    [HttpPut("{id:guid}")]

    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateEventRequestDto dto)
    {
        var @event = await dbContext.Events.FindAsync(id, HttpContext.RequestAborted);
        if (@event is null) return NotFound();
        
        @event.Title = dto.Title;
        @event.Description = dto.Description;
        @event.StartTime = dto.StartTime;
        @event.EndTime = dto.EndTime;
        @event.LocationType = dto.LocationType;
        @event.Location = dto.Location;
        @event.UpdatedAt = DateTime.UtcNow;
        
        await dbContext.SaveChangesAsync(HttpContext.RequestAborted);

        return NoContent();
    } 

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var @event = await dbContext.Events.FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (@event is null) return NotFound();
        
        dbContext.Remove(@event);
        await dbContext.SaveChangesAsync(HttpContext.RequestAborted);
        
        return Ok();
    }
}