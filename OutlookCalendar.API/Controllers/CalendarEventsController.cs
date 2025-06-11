using Microsoft.AspNetCore.Mvc;
using OutlookCalendar.Core.DTOs;
using OutlookCalendar.Core.Interfaces;

namespace OutlookCalendar.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalendarEventsController(ICalendarEventService calendarEventService) : ControllerBase
{
    private readonly ICalendarEventService _calendarEventService = calendarEventService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CalendarEventDto>>> GetEvents(
        [FromQuery] DateTime start,
        [FromQuery] DateTime end)
    {
        var events = await _calendarEventService.GetEventsAsync(start, end);
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CalendarEventDto>> GetEvent(int id)
    {
        try
        {
            var calendarEvent = await _calendarEventService.GetEventByIdAsync(id);
            return Ok(calendarEvent);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<CalendarEventDto>> CreateEvent(CalendarEventDto eventDto)
    {
        try
        {
            var createdEvent = await _calendarEventService.CreateEventAsync(eventDto);
            return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, CalendarEventDto eventDto)
    {
        try
        {
            await _calendarEventService.UpdateEventAsync(id, eventDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        try
        {
            await _calendarEventService.DeleteEventAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("recurring")]
    public async Task<ActionResult<IEnumerable<CalendarEventDto>>> GetRecurringEvents(
        [FromQuery] DateTime start,
        [FromQuery] DateTime end,
        [FromQuery] string recurrenceRule)
    {
        try
        {
            var events = await _calendarEventService.GetEventsAsync(start, end);
            // Filter events based on recurrence rule
            var recurringEvents = events.Where(e => e.RecurrenceRule == recurrenceRule);
            return Ok(recurringEvents);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}