using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Center.API.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileNumber { get; set; } = string.Empty;

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Required]
        public string PatientComplaint { get; set; } = string.Empty;

        public string? DiagnosisNotes { get; set; }

        public string? DoctorNotes { get; set; }

        public string? TreatmentPlan { get; set; }

        public int? Age { get; set; }

        public string? EducationalLevel { get; set; }

        public string? SocialStatus { get; set; }

        public string? Occupation { get; set; }

        public string? PatientPhone { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public virtual User? Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual User? Doctor { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session? Session { get; set; }
    }
}
