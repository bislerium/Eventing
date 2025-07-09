using Eventing.ApiService.Controllers.Event.Dto;
using Eventing.ApiService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Controllers.Event;

[ApiConventionType(typeof(DefaultApiConventions))]
public class EventsController(EventingDbContext dbContext) : ApiBaseController
{
    [HttpGet]
    public Task<List<EventResponseDto>> GetAll([FromQuery] string? search)
        => dbContext.Events.Where(x => search == null || x.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => new EventResponseDto(x.Id, x.Title, x.Description, x.StartTime, x.EndTime,
                x.LocationType, x.Location, x.CreatedBy, x.CreatedAt, x.UpdatedAt))
            .ToListAsync(HttpContext.RequestAborted);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EventResponseDto>> GetById([FromRoute] Guid id)
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
    public async Task<IActionResult> Create([FromBody] CreateEventRequestDto dto)
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

        return CreatedAtAction(nameof(GetById), new { id = @event.Id }, null);
    }
}