namespace OutlookCalendar.Domain.Models;

public class CalendarEvent // Renamed from Event to avoid conflict
{
    public int Id { get; set; }
    public required string Title { get; set; }
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
    public required string CreatedBy { get; set; }
    public List<CalendarEventShare> SharedWith { get; set; } = new();
}

public class CalendarEventShare // Renamed from EventShare to avoid conflict
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public required string SharedWithUserId { get; set; }
    public bool CanEdit { get; set; }
}