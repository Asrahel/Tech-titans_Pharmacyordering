using Microsoft.EntityFrameworkCore;
using PharmacyOrderingApi.Data;

namespace PharmacyOrderingApi.Repositories.Prescription
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly AppDbContext _context;

        public PrescriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Prescription> AddAsync(Models.Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task<List<Models.Prescription>> GetByUserIdAsync(int userId)
        {
            return await _context.Prescriptions
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }
    }
}