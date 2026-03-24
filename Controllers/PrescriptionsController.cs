using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyOrderingApi.Services.Prescription;
using System.Security.Claims;

namespace PharmacyOrderingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionsController(IPrescriptionService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("User id not found in token");

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user id");

            var result = await _service.UploadAsync(userId, file);
            return Ok(result);
        }
    }
}