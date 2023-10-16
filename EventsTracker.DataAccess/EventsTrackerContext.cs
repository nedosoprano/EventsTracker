using EventsTracker.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsTracker.DataAccess
{
    public class EventsTrackerContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventsTrackerContext(DbContextOptions<EventsTrackerContext> options) : base(options)
        { 
        }
    }
}
