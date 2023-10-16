using EventsTracker.DataAccess.Models;

namespace EventsTracker.Application.Models
{
    public class EventsPerDate
    {
        public DateTime Date { get; set; }

        public IEnumerable<Event> Events { get; set; }

        public EventsPerDate() 
        {
            Events = new List<Event>();
        }

        public EventsPerDate(DateTime date, IEnumerable<Event> events) 
        { 
            Date = date;
            Events = events;
        }
    }
}
