using System.Text.Json.Serialization;

namespace EventsTracker.DataAccess.Models
{
    public class Event
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; }
    }
}