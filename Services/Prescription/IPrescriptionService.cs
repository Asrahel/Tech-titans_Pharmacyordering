using Microsoft.AspNetCore.Http;
using PharmacyOrderingApi.DTOs.Prescription;

namespace PharmacyOrderingApi.Services.Prescription
{
    public interface IPrescriptionService
    {
        Task<PrescriptionResponseDto> UploadAsync(int userId, IFormFile file);
    }
}