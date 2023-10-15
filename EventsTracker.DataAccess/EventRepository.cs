using EventsTracker.DataAccess.Models;

namespace EventsTracker.DataAccess
{
    public class EventRepository : IRepository<Event>
    {
        private List<Event> _events = new List<Event>();

        public void Add(Event entity)
        {
            _events.Add(entity);
        }

        public void AddRange(IEnumerable<Event> entities)
        {
            _events.AddRange(entities);
        }
    }
}
