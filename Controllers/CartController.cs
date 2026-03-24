using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyOrderingApi.DTOs.Cart;
using PharmacyOrderingApi.Services.Cart;
using System.Security.Claims;

namespace PharmacyOrderingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddCartItemDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(new { message = await _service.AddToCartAsync(userId, dto) });
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyCart()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(await _service.GetCartAsync(userId));
        }
    }
}