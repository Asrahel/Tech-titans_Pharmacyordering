using PharmacyOrderingApi.DTOs.Cart;

namespace PharmacyOrderingApi.Services.Cart
{
    public interface ICartService
    {
        Task<string> AddToCartAsync(int userId, AddCartItemDto dto);
        Task<object?> GetCartAsync(int userId);
    }
}