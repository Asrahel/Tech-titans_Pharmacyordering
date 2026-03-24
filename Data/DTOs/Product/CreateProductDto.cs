using System.ComponentModel.DataAnnotations;

namespace PharmacyOrderingApi.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public string Dosage { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}