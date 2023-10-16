using EventsTracker.DataAccess.Models;

namespace EventsTracker.DataAccess
{
    public class EventRepository : IEventRepository
    {
        private List<Event> _events = new List<Event>()
        {
            new Event
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Parse("2023-12-1"),
                Title = "event1"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Parse("2022-12-14"),
                Title = "event2"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Parse("2022-12-15"),
                Title = "event3"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Parse("2023-12-31"),
                Title = "event4"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Parse("2023-12-16"),
                Title = "event5"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Parse("2023-12-31"),
                Title = "event6"
            },
        };

        public void AddEvents(IEnumerable<Event> events)
        {
            _events.AddRange(events);
        }

        public IEnumerable<Event> GetEventsInInterval(DateTime startDate, DateTime endDate)
        {
            return _events.Where(e => e.Date >= startDate && e.Date <= endDate);
        }
    }
}
