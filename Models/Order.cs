using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyOrderingApi.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Placed";

        public int? PrescriptionId { get; set; }

        [ForeignKey("PrescriptionId")]
        public Prescription? Prescription { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();

        public Payment? Payment { get; set; }

        public User? User { get; set; }
    }
}