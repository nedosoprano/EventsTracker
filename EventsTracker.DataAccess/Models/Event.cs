using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventsTracker.DataAccess.Models
{
    [Table("events")]
    public class Event
    {
        [JsonIgnore]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [JsonIgnore]
        [Column("date")]
        public DateTime Date { get; set; }
    }
}