using PharmacyOrderingApi.DTOs.Auth;

namespace PharmacyOrderingApi.Services.Auth
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
    }
}