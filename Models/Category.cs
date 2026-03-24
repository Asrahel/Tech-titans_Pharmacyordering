using System.ComponentModel.DataAnnotations;

namespace PharmacyOrderingApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}