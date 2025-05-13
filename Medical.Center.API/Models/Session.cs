using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Center.API.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? Notes { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("PatientId")]
        public virtual User? Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual User? Doctor { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }

        public virtual ICollection<Diagnosis>? Diagnoses { get; set; }
    }
}
