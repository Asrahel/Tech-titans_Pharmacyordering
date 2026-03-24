using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<Models.Product>> GetAllAsync();
        Task<Models.Product?> GetByIdAsync(int id);
        Task<Models.Product> AddAsync(Models.Product product);
    }
}