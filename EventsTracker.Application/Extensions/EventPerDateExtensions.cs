using EventsTracker.Application.Models;
using EventsTracker.DataAccess.Models;

namespace EventsTracker.Application.Extensions
{
    internal static class EventPerDateExtensions
    {
        internal static IEnumerable<Event> ConvertToEvents(this EventsPerDate eventsPerDate)
        {
            var events = new List<Event>();

            foreach (var e in eventsPerDate.Events)
            {
                e.Id = Guid.NewGuid();
                e.Date = eventsPerDate.Date;

                events.Add(e);
            }

            return events;
        }
    }
}
