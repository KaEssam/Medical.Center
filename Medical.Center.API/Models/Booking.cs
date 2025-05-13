using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Center.API.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Required]
        public string MeetingLink { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string Type { get; set; } = "Regular";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Status { get; set; } = "Scheduled";

        public string PaymentStatus { get; set; } = "Pending";

        public bool IsFreeSession { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public virtual User? Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual User? Doctor { get; set; }

        [ForeignKey("ScheduleId")]
        public virtual DoctorSchedule? Schedule { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session? Session { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
