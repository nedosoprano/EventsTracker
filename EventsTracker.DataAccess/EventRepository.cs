using EventsTracker.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsTracker.DataAccess
{
    /// <summary>
    /// Interacts with events tracker database.
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// Creates new events.
        /// </summary>
        Task CreateEventsAsync(IEnumerable<Event> entities, CancellationToken cancellationToken);

        /// <summary>
        /// Gets all days of the month with events for a certain month and year.
        /// </summary>
        Task<IEnumerable<Event>> GetEventsInIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }

    /// <inheritdoc/>
    public class EventRepository : IEventRepository
    {
        private readonly EventsTrackerContext _eventsTrackerContext;

        public EventRepository(EventsTrackerContext eventsTrackerContext)
        {
            _eventsTrackerContext = eventsTrackerContext;
        }

        /// <inheritdoc/>
        public async Task CreateEventsAsync(IEnumerable<Event> events, CancellationToken cancellationToken)
        {
            _eventsTrackerContext.Events.AddRange(events);

            await _eventsTrackerContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Event>> GetEventsInIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return await _eventsTrackerContext.Events.Where(e => e.Date >= startDate && e.Date <= endDate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
