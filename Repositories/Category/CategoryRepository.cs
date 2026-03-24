using Microsoft.EntityFrameworkCore;
using PharmacyOrderingApi.Data;

namespace PharmacyOrderingApi.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Models.Category> AddAsync(Models.Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}