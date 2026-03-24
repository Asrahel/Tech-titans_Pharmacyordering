using PharmacyOrderingApi.DTOs.Product;
using PharmacyOrderingApi.Repositories.Product;

namespace PharmacyOrderingApi.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Models.Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Models.Product?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Models.Product> AddAsync(CreateProductDto dto)
        {
            var product = new Models.Product
            {
                Name = dto.Name.Trim(),
                Description = dto.Description.Trim(),
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Dosage = dto.Dosage.Trim(),
                ExpiryDate = dto.ExpiryDate,
                CategoryId = dto.CategoryId
            };

            return await _repository.AddAsync(product);
        }
    }
}