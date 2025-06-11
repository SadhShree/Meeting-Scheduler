namespace OutlookCalendar.Core.DTOs;

public class CalendarEventDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
    public string? TimeZone { get; set; }
    public string? RecurrenceRule { get; set; }
    public string? Category { get; set; }
    public string? Color { get; set; }
    public int? ReminderMinutes { get; set; }
}