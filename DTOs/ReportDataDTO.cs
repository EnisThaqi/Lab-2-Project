namespace Lab2.DTOs
{
    public class ReportDataDTO
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public string ReceiverName { get; set; }
        public decimal Weight { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReferenceCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrderStatus { get; set; }
    }
}
