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
        public async Task<IActionResult> GetEvents([FromQuery] int year, [FromQuery] string month, CancellationToken cancellationToken)
        {
            var eventsPerDate = await _eventsPerDateService.GetEventsInIntervalAsync(year, month, cancellationToken);

            return Ok(eventsPerDate);
        }

        [HttpPost("addevents")]
        public async Task<IActionResult> AddEvents(EventsPerDate eventsPerDate, CancellationToken cancellationToken)
        {
            await _eventsPerDateService.AddEventsAsync(eventsPerDate, cancellationToken);

            return Created("/addevents", null);
        }
    }
}