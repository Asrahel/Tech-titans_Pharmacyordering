using PharmacyOrderingApi.DTOs.Order;

namespace PharmacyOrderingApi.Services.Order
{
    public interface IOrderService
    {
        Task<string> PlaceOrderAsync(int userId, PlaceOrderDto dto);
        Task<object> GetMyOrdersAsync(int userId);
    }
}