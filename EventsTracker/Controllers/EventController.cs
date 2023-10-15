using EventsTracker.Application.Models;
using EventsTracker.Application;
using Microsoft.AspNetCore.Mvc;

namespace EventsTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private IService<EventsPerDate> _eventService;

        public EventController(IService<EventsPerDate> eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("addevents")]
        public IActionResult AddEvents(EventsPerDate eventsPerDate)
        {
            _eventService.Add(eventsPerDate);

            return Created("/addevents", null);
        }
    }
}