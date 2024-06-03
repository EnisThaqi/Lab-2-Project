namespace Lab2.DTOs
{
    public class ReportCriteriaDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverCountry { get; set; }
        public string OrderStatus { get; set; }
    }
}
