using PharmacyOrderingApi.DTOs.Category;

namespace PharmacyOrderingApi.Services.Category
{
    public interface ICategoryService
    {
        Task<List<Models.Category>> GetAllAsync();
        Task<Models.Category> AddAsync(CategoryDto dto);
    }
}