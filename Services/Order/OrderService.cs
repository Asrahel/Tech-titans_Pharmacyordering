using PharmacyOrderingApi.DTOs.Order;
using PharmacyOrderingApi.Repositories.Order;

namespace PharmacyOrderingApi.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> PlaceOrderAsync(int userId, PlaceOrderDto dto)
        {
            var cart = await _repository.GetCartByUserIdAsync(userId);

            if (cart == null || cart.CartItems == null || !cart.CartItems.Any())
                return "Cart is empty";

            foreach (var item in cart.CartItems)
            {
                if (item.Product == null)
                    return "Product not found";

                if (item.Product.StockQuantity < item.Quantity)
                    return $"Insufficient stock for {item.Product.Name}";
            }

            var totalAmount = cart.CartItems.Sum(x => x.Quantity * x.Product!.Price);

            var order = new Models.Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                Status = "Placed",
                PrescriptionId = dto.PrescriptionId,
                TotalAmount = totalAmount,
                OrderItems = cart.CartItems.Select(ci => new Models.OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = ci.Product!.Price
                }).ToList(),
                Payment = new Models.Payment
                {
                    Amount = totalAmount,
                    PaymentMethod = dto.PaymentMethod,
                    PaymentStatus = "Pending",
                    PaymentDate = DateTime.UtcNow
                }
            };

            foreach (var item in cart.CartItems)
            {
                item.Product!.StockQuantity -= item.Quantity;
            }

            cart.CartItems.Clear();

            await _repository.AddOrderAsync(order);
            await _repository.SaveAsync();

            return "Order placed successfully";
        }

        public async Task<object> GetMyOrdersAsync(int userId)
        {
            var orders = await _repository.GetOrdersByUserIdAsync(userId);

            return orders.Select(o => new
            {
                o.OrderId,
                o.OrderDate,
                o.TotalAmount,
                o.Status,
                o.PrescriptionId,
                Payment = o.Payment == null ? null : new
                {
                    o.Payment.PaymentMethod,
                    o.Payment.PaymentStatus,
                    o.Payment.Amount,
                    o.Payment.PaymentDate
                },
                Items = o.OrderItems.Select(i => new
                {
                    i.ProductId,
                    ProductName = i.Product != null ? i.Product.Name : string.Empty,
                    i.Quantity,
                    i.Price
                }).ToList()
            }).ToList();
        }
    }
}