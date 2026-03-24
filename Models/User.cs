using System.ComponentModel.DataAnnotations;

namespace PharmacyOrderingApi.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Customer";

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}