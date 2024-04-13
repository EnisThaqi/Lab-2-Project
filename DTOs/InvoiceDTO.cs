namespace Lab2.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }

        public DateTime Issued_Date { get; set; }

        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int SubjectId { get; set; }
    }
}