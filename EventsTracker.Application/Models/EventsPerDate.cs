using EventsTracker.DataAccess.Models;

namespace EventsTracker.Application.Models
{
    /// <summary>
    /// Represents events that occurred in the same date.
    /// </summary>
    public class EventsPerDate
    {
        /// <summary>
        /// Events date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The events.
        /// </summary>
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
