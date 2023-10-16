using EventsTracker.Application.Models;
using EventsTracker.Application;
using Microsoft.AspNetCore.Mvc;

namespace EventsTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private IEventsPerDateService _eventsPerDateService;

        public EventController(IEventsPerDateService eventsPerDateService)
        {
            _eventsPerDateService = eventsPerDateService;
        }

        [HttpGet("getevents")]
        public IActionResult GetEvents([FromQuery] int year, [FromQuery] string month)
        {
            var eventsPerDate = _eventsPerDateService.GetEventsInInterval(year, month);

            return Ok(eventsPerDate);
        }

        [HttpPost("addevents")]
        public IActionResult AddEvents(EventsPerDate eventsPerDate)
        {
            _eventsPerDateService.AddEvents(eventsPerDate);

            return Created("/addevents", null);
        }
    }
}