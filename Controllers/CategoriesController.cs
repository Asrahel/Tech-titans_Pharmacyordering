using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyOrderingApi.DTOs.Category;
using PharmacyOrderingApi.Services.Category;

namespace PharmacyOrderingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _service.AddAsync(dto));
        }
    }
}