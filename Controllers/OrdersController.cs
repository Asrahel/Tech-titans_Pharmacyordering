using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyOrderingApi.DTOs.Order;
using PharmacyOrderingApi.Services.Order;
using System.Security.Claims;

namespace PharmacyOrderingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder(PlaceOrderDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _service.PlaceOrderAsync(userId, dto);

            if (result != "Order placed successfully")
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }

        [HttpGet("my")]
        public async Task<IActionResult> MyOrders()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(await _service.GetMyOrdersAsync(userId));
        }
    }
}