using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Repositories.Order
{
    public interface IOrderRepository
    {
        Task<Models.Cart?> GetCartByUserIdAsync(int userId);
        Task AddOrderAsync(Models.Order order);
        Task<List<Models.Order>> GetOrdersByUserIdAsync(int userId);
        Task SaveAsync();
    }
}