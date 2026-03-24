using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PharmacyOrderingApi.Data;
using PharmacyOrderingApi.DTOs.Prescription;

namespace PharmacyOrderingApi.Services.Prescription
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PrescriptionService(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<PrescriptionResponseDto> UploadAsync(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("No file uploaded");

            var webRootPath = _environment.WebRootPath;

            if (string.IsNullOrEmpty(webRootPath))
            {
                webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            var uploadsFolder = Path.Combine(webRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var fullFilePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var prescription = new Models.Prescription
            {
                UserId = userId,
                FilePath = $"uploads/{uniqueFileName}",
                UploadedDate = DateTime.UtcNow,
                Status = "Pending"
            };

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            return new PrescriptionResponseDto
            {
                PrescriptionId = prescription.PrescriptionId,
                UserId = prescription.UserId,
                FilePath = prescription.FilePath,
                UploadedDate = prescription.UploadedDate,
                Status = prescription.Status
            };
        }
    }
}