using EventsTracker.Application.Models;

namespace EventsTracker.Application
{
    public interface IEventsPerDateService
    {
        public void AddEvents(EventsPerDate eventsPerDate);

        public IEnumerable<EventsPerDate> GetEventsInInterval(int year, string month);
    }
}
