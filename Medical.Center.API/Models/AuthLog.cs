using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Center.API.Models
{
    public class AuthLog
    {
        [Key]
        public int LogId { get; set; }        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Action { get; set; } = string.Empty;

        [Required]
        public string IpAddress { get; set; } = string.Empty;

        [Required]
        public string UserAgent { get; set; } = string.Empty;

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
