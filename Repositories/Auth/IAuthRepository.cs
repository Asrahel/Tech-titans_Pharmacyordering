using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
    }
}