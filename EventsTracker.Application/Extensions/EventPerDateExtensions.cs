using EventsTracker.Application.Models;
using EventsTracker.DataAccess.Models;

namespace EventsTracker.Application.Extensions
{
    /// <summary>
    /// Extensions for <see cref="EventsPerDate"/>.
    /// </summary>
    internal static class EventPerDateExtensions
    {
        /// <summary>
        /// Converts <see cref="EventsPerDate"/> instance to a list of <see cref="Event"/>.
        /// </summary>
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
