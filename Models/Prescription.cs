using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyOrderingApi.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public DateTime UploadedDate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        public User? User { get; set; }
    }
}