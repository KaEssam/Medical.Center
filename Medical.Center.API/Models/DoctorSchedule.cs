using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Center.API.Models
{
    public class DoctorSchedule
    {
        [Key]
        public int Id { get; set; }        [Required]
        public string DoctorId { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("DoctorId")]
        public virtual User? Doctor { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
