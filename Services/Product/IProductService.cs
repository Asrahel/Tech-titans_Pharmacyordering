using PharmacyOrderingApi.DTOs.Product;

namespace PharmacyOrderingApi.Services.Product
{
    public interface IProductService
    {
        Task<List<Models.Product>> GetAllAsync();
        Task<Models.Product?> GetByIdAsync(int id);
        Task<Models.Product> AddAsync(CreateProductDto dto);
    }
}