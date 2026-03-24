using PharmacyOrderingApi.DTOs.Cart;
using PharmacyOrderingApi.Repositories.Cart;

namespace PharmacyOrderingApi.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> AddToCartAsync(int userId, AddCartItemDto dto)
        {
            var cart = await _repository.GetCartByUserIdAsync(userId);

            if (cart == null)
                return "Cart not found";

            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == dto.ProductId);

            if (existingItem != null)
                existingItem.Quantity += dto.Quantity;
            else
                cart.CartItems.Add(new Models.CartItem
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                });

            await _repository.SaveAsync();
            return "Item added to cart";
        }

        public async Task<object?> GetCartAsync(int userId)
        {
            var cart = await _repository.GetCartByUserIdAsync(userId);
            if (cart == null) return null;

            return new
            {
                cart.CartId,
                cart.UserId,
                Items = cart.CartItems.Select(ci => new
                {
                    ci.CartItemId,
                    ci.ProductId,
                    ProductName = ci.Product!.Name,
                    ci.Quantity,
                    ci.Product.Price,
                    Total = ci.Quantity * ci.Product.Price
                })
            };
        }
    }
}