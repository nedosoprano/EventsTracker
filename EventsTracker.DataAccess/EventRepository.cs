using EventsTracker.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsTracker.DataAccess
{
    public interface IEventRepository
    {
        Task AddEventsAsync(IEnumerable<Event> entities, CancellationToken cancellationToken);

        Task<IEnumerable<Event>> GetEventsInIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }

    public class EventRepository : IEventRepository
    {
        private readonly EventsTrackerContext _eventsTrackerContext;

        public EventRepository(EventsTrackerContext eventsTrackerContext)
        {
            _eventsTrackerContext = eventsTrackerContext;
        }

        public async Task AddEventsAsync(IEnumerable<Event> events, CancellationToken cancellationToken)
        {
            _eventsTrackerContext.Events.AddRange(events);

            await _eventsTrackerContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Event>> GetEventsInIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return await _eventsTrackerContext.Events.Where(e => e.Date >= startDate && e.Date <= endDate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
