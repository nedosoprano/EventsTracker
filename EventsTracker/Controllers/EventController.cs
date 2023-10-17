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

        /// <summary>
        /// Creates new events.
        /// </summary>
        /// <param name="eventsPerDate">The events data.</param>
        [HttpGet("get")]
        public async Task<IActionResult> GetEvents([FromQuery] int year, [FromQuery] string month, CancellationToken cancellationToken)
        {
            var eventsPerDate = await _eventsPerDateService.GetEventsInIntervalAsync(year, month, cancellationToken);

            return Ok(eventsPerDate);
        }

        /// <summary>
        /// Gets events all days of the month with events for a certain month and year.
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateEvents(EventsPerDate eventsPerDate, CancellationToken cancellationToken)
        {
            await _eventsPerDateService.CreateEventsAsync(eventsPerDate, cancellationToken);

            return Created("/create", null);
        }
    }
}