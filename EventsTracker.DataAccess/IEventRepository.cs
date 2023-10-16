using EventsTracker.DataAccess.Models;

namespace EventsTracker.DataAccess
{
    public interface IEventRepository
    {
        void AddEvents(IEnumerable<Event> entities);

        IEnumerable<Event> GetEventsInInterval(DateTime startDate, DateTime endDate);
    }
}
