using OutlookCalendar.Core.DTOs;
using OutlookCalendar.Domain.Models;

namespace OutlookCalendar.Core.Interfaces;

public interface ICalendarEventService
{
    Task<IEnumerable<CalendarEventDto>> GetEventsAsync(DateTime start, DateTime end);
    Task<CalendarEventDto> GetEventByIdAsync(int id);
    Task<CalendarEventDto> CreateEventAsync(CalendarEventDto eventDto);
    Task<CalendarEventDto> UpdateEventAsync(int id, CalendarEventDto eventDto);
    Task DeleteEventAsync(int id);
}