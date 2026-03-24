namespace PharmacyOrderingApi.DTOs.Order
{
    public class PlaceOrderDto
    {
        public int? PrescriptionId { get; set; }
        public string PaymentMethod { get; set; } = "Cash On Delivery";
    }
}