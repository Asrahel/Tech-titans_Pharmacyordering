using Microsoft.EntityFrameworkCore;
using PharmacyOrderingApi.Data;

namespace PharmacyOrderingApi.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Models.Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Models.Product> AddAsync(Models.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}