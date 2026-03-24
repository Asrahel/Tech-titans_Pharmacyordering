using Microsoft.EntityFrameworkCore;
using PharmacyOrderingApi.Data;
using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            _context.Carts.Add(new PharmacyOrderingApi.Models.Cart
            {
                UserId = user.UserId
            });

            await _context.SaveChangesAsync();

            return user;
        }
    }
}