using EventsTracker.DataAccess.Models;

namespace EventsTracker.DataAccess
{
    public interface IEventRepository
    {
        void AddEvents(IEnumerable<Event> entities);

        IEnumerable<Event> GetEventsInInterval(DateTime startDate, DateTime endDate);
    }

    public class EventRepository : IEventRepository
    {
        private readonly EventsTrackerContext _eventsTrackerContext;

        public EventRepository(EventsTrackerContext eventsTrackerContext)
        {
            _eventsTrackerContext = eventsTrackerContext;
        }

        public void AddEvents(IEnumerable<Event> events)
        {
            _eventsTrackerContext.Events.AddRange(events);
            _eventsTrackerContext.SaveChanges();
        }

        public IEnumerable<Event> GetEventsInInterval(DateTime startDate, DateTime endDate)
        {
            return _eventsTrackerContext.Events.Where(e => e.Date >= startDate && e.Date <= endDate);
        }
    }
}
