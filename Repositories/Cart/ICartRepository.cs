using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Repositories.Cart
{
    public interface ICartRepository
    {
        Task<Models.Cart?> GetCartByUserIdAsync(int userId);
        Task SaveAsync();
    }
}