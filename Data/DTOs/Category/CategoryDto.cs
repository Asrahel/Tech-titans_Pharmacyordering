using System.ComponentModel.DataAnnotations;

namespace PharmacyOrderingApi.DTOs.Category
{
    public class CategoryDto
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}