using PharmacyOrderingApi.DTOs.Auth;
using PharmacyOrderingApi.Helpers;
using PharmacyOrderingApi.Models;
using PharmacyOrderingApi.Repositories.Auth;

namespace PharmacyOrderingApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly JwtService _jwtService;

        public AuthService(IAuthRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _repository.GetUserByEmailAsync(dto.Email.Trim());

            if (existingUser != null)
                return "Email already exists";

            var user = new User
            {
                Name = dto.Name.Trim(),
                Email = dto.Email.Trim(),
                Password = dto.Password,
                Role = "Customer"
            };

            await _repository.AddUserAsync(user);
            return "Customer registered successfully";
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _repository.GetUserByEmailAsync(dto.Email.Trim());

            if (user == null || user.Password != dto.Password)
                return null;

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
        }
    }
}