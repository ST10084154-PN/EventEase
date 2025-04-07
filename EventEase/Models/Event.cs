// Models/Event.cs
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Start Date and Time")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date and Time")]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Booking> Bookings { get; set; }
    }
}