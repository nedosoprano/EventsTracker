using EventsTracker.Application.Extensions;
using EventsTracker.Application.Models;
using EventsTracker.DataAccess;
using System.Globalization;

namespace EventsTracker.Application
{
    public interface IEventsPerDateService
    {
        public Task AddEventsAsync(EventsPerDate eventsPerDate, CancellationToken cancellationToken);

        public Task<IEnumerable<EventsPerDate>> GetEventsInIntervalAsync(int year, string month, CancellationToken cancellationToken);
    }

    public class EventsPerDateService : IEventsPerDateService
    {
        private IEventRepository _eventRepository;

        public EventsPerDateService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task AddEventsAsync(EventsPerDate eventsPerDate, CancellationToken cancellationToken)
        {
            var events = eventsPerDate.ConvertToEvents();

            await _eventRepository.AddEventsAsync(events, cancellationToken);
        }

        public async Task<IEnumerable<EventsPerDate>> GetEventsInIntervalAsync(int year, string monthName, CancellationToken cancellationToken)
        {
            int month = DateTime.ParseExact(monthName, "MMMM", CultureInfo.InvariantCulture).Month;
            int monthLastDay = DateTime.DaysInMonth(year, month);

            var startDate = new DateTime(year, month, 1);
            var endDate = new DateTime(year, month, monthLastDay);

            var events = await _eventRepository.GetEventsInIntervalAsync(startDate, endDate, cancellationToken);

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