namespace PharmacyOrderingApi.DTOs.Prescription
{
    public class PrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadedDate { get; set; }
    }
}