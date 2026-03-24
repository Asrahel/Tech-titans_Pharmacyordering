using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Repositories.Category
{
    public interface ICategoryRepository
    {
        Task<List<Models.Category>> GetAllAsync();
        Task<Models.Category> AddAsync(Models.Category category);
    }
}