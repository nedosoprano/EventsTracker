using EventsTracker.Application.Extensions;
using EventsTracker.Application.Models;
using EventsTracker.DataAccess;
using EventsTracker.DataAccess.Models;

namespace EventsTracker.Application
{
    public class EventsPerDateService : IService<EventsPerDate>
    {
        private IRepository<Event> _eventRepository;

        public EventsPerDateService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Add(EventsPerDate entity)
        {
            IEnumerable<Event> events = entity.ConvertToEvents();

            _eventRepository.AddRange(events);
        }
    }
}