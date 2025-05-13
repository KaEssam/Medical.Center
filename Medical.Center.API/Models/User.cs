using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Medical.Center.API.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public override string Email { get; set; }
        
        [Phone]
        public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        public string? ProfilePictureUrl { get; set; }

        public string Status { get; set; } = "Active";

        public string? Description { get; set; }

        public string? CertificatePath { get; set; }

        public string? NationalId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public string? Role { get; set; }
        public bool HasMedFreeSession { get; set; }

        // Navigation properties
        public virtual ICollection<Booking>? BookingsAsPatient { get; set; }
        public virtual ICollection<Booking>? BookingsAsDoctor { get; set; }
        public virtual ICollection<DoctorSchedule>? DoctorSchedules { get; set; }
        public virtual ICollection<Session>? SessionsAsPatient { get; set; }
        public virtual ICollection<Session>? SessionsAsDoctor { get; set; }
        public virtual ICollection<Diagnosis>? DiagnosesAsPatient { get; set; }
        public virtual ICollection<Diagnosis>? DiagnosesAsDoctor { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<AuthLog>? AuthLogs { get; set; }
    }
}
