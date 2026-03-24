namespace PharmacyOrderingApi.DTOs.Prescription
{
    public class PrescriptionResponseDto
    {
        public int PrescriptionId { get; set; }
        public int UserId { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadedDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}