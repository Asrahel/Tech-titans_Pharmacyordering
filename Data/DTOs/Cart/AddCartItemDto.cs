using System.ComponentModel.DataAnnotations;

namespace PharmacyOrderingApi.DTOs.Cart
{
    public class AddCartItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}