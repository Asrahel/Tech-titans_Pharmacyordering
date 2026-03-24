using PharmacyOrderingApi.Models;

namespace PharmacyOrderingApi.Repositories.Prescription
{
    public interface IPrescriptionRepository
    {
        Task<Models.Prescription> AddAsync(Models.Prescription prescription);
        Task<List<Models.Prescription>> GetByUserIdAsync(int userId);
    }
}