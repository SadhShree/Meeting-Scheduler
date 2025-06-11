using Microsoft.EntityFrameworkCore;
using OutlookCalendar.Domain.Models;

namespace OutlookCalendar.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CalendarEvent> CalendarEvents => Set<CalendarEvent>();
    public DbSet<CalendarEventShare> CalendarEventShares => Set<CalendarEventShare>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CalendarEvent>()
            .HasMany(e => e.SharedWith)
            .WithOne()
            .HasForeignKey(es => es.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}