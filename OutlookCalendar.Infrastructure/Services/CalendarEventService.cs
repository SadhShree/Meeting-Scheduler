using Microsoft.EntityFrameworkCore;
using OutlookCalendar.Core.DTOs;
using OutlookCalendar.Core.Interfaces;
using OutlookCalendar.Domain.Models;
using OutlookCalendar.Infrastructure.Data;

namespace OutlookCalendar.Infrastructure.Services;

public class CalendarEventService(ApplicationDbContext context) : ICalendarEventService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<CalendarEventDto>> GetEventsAsync(DateTime start, DateTime end)
    {
        return await _context.CalendarEvents
            .Where(e => e.StartTime <= end && e.EndTime >= start)
            .Select(e => new CalendarEventDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Location = e.Location,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                IsAllDay = e.IsAllDay,
                TimeZone = e.TimeZone,
                RecurrenceRule = e.RecurrenceRule,
                Category = e.Category,
                Color = e.Color,
                ReminderMinutes = e.ReminderMinutes
            })
            .ToListAsync();
    }

    public async Task<CalendarEventDto> GetEventByIdAsync(int id)
    {
        var calendarEvent = await _context.CalendarEvents.FindAsync(id)
            ?? throw new KeyNotFoundException($"Event with ID {id} not found");

        return new CalendarEventDto
        {
            Id = calendarEvent.Id,
            Title = calendarEvent.Title,
            Description = calendarEvent.Description,
            Location = calendarEvent.Location,
            StartTime = calendarEvent.StartTime,
            EndTime = calendarEvent.EndTime,
            IsAllDay = calendarEvent.IsAllDay,
            TimeZone = calendarEvent.TimeZone,
            RecurrenceRule = calendarEvent.RecurrenceRule,
            Category = calendarEvent.Category,
            Color = calendarEvent.Color,
            ReminderMinutes = calendarEvent.ReminderMinutes
        };
    }

    public async Task<CalendarEventDto> CreateEventAsync(CalendarEventDto eventDto)
    {
        var calendarEvent = new CalendarEvent
        {
            Title = eventDto.Title,
            Description = eventDto.Description,
            Location = eventDto.Location,
            StartTime = eventDto.StartTime,
            EndTime = eventDto.EndTime,
            IsAllDay = eventDto.IsAllDay,
            TimeZone = eventDto.TimeZone,
            RecurrenceRule = eventDto.RecurrenceRule,
            Category = eventDto.Category,
            Color = eventDto.Color,
            ReminderMinutes = eventDto.ReminderMinutes,
            CreatedBy = "system" // TODO: Replace with actual user ID from authentication
        };

        _context.CalendarEvents.Add(calendarEvent);
        await _context.SaveChangesAsync();

        eventDto.Id = calendarEvent.Id;
        return eventDto;
    }

    public async Task<CalendarEventDto> UpdateEventAsync(int id, CalendarEventDto eventDto)
    {
        var calendarEvent = await _context.CalendarEvents.FindAsync(id)
            ?? throw new KeyNotFoundException($"Event with ID {id} not found");

        calendarEvent.Title = eventDto.Title;
        calendarEvent.Description = eventDto.Description;
        calendarEvent.Location = eventDto.Location;
        calendarEvent.StartTime = eventDto.StartTime;
        calendarEvent.EndTime = eventDto.EndTime;
        calendarEvent.IsAllDay = eventDto.IsAllDay;
        calendarEvent.TimeZone = eventDto.TimeZone;
        calendarEvent.RecurrenceRule = eventDto.RecurrenceRule;
        calendarEvent.Category = eventDto.Category;
        calendarEvent.Color = eventDto.Color;
        calendarEvent.ReminderMinutes = eventDto.ReminderMinutes;

        await _context.SaveChangesAsync();
        return eventDto;
    }

    public async Task DeleteEventAsync(int id)
    {
        var calendarEvent = await _context.CalendarEvents.FindAsync(id)
            ?? throw new KeyNotFoundException($"Event with ID {id} not found");

        _context.CalendarEvents.Remove(calendarEvent);
        await _context.SaveChangesAsync();
    }
}