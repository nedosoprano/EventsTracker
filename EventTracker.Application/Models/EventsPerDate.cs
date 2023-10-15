using EventsTracker.DataAccess.Models;

namespace EventsTracker.Application.Models
{
    public class EventsPerDate
    {
        public DateTime Date { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
