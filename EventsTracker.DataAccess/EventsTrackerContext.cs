using EventsTracker.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsTracker.DataAccess
{
    /// <summary>
    /// Events tracker db context.
    /// </summary>
    public class EventsTrackerContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventsTrackerContext(DbContextOptions<EventsTrackerContext> options) : base(options)
        { 
        }
    }
}
