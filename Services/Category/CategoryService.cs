using PharmacyOrderingApi.DTOs.Category;
using PharmacyOrderingApi.Repositories.Category;

namespace PharmacyOrderingApi.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Models.Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Models.Category> AddAsync(CategoryDto dto)
        {
            var category = new Models.Category
            {
                CategoryName = dto.CategoryName.Trim()
            };

            return await _repository.AddAsync(category);
        }
    }
}