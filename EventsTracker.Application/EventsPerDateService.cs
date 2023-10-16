using EventsTracker.Application.Extensions;
using EventsTracker.Application.Models;
using EventsTracker.DataAccess;
using System.Globalization;

namespace EventsTracker.Application
{
    public interface IEventsPerDateService
    {
        public void AddEvents(EventsPerDate eventsPerDate);

        public IEnumerable<EventsPerDate> GetEventsInInterval(int year, string month);
    }

    public class EventsPerDateService : IEventsPerDateService
    {
        private IEventRepository _eventRepository;

        public EventsPerDateService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void AddEvents(EventsPerDate eventsPerDate)
        {
            var events = eventsPerDate.ConvertToEvents();

            _eventRepository.AddEvents(events);
        }

        public IEnumerable<EventsPerDate> GetEventsInInterval(int year, string monthName)
        {
            int month = DateTime.ParseExact(monthName, "MMMM", CultureInfo.InvariantCulture).Month;
            int monthLastDay = DateTime.DaysInMonth(year, month);

            var startDate = new DateTime(year, month, 1);
            var endDate = new DateTime(year, month, monthLastDay);

            var events = _eventRepository.GetEventsInInterval(startDate, endDate);

            var grouppedEvents = events.GroupBy(e => e.Date);

            var eventsPerDateList = new List<EventsPerDate>();

            foreach (var group in grouppedEvents)
            {
                var eventsPerDate = new EventsPerDate(group.Key, group.ToList());
                eventsPerDateList.Add(eventsPerDate);
            }

            return eventsPerDateList;
        }
    }
}