namespace Lab2.DTOs
{
    public class PaymentsDTO
    {
        public int PaymentsID { get; set; }

        public decimal Amount { get; set; }

        public int InvoiceID { get; set; }

        public int PaymentMethodsID { get; set; }

        public bool Payed { get; set; }
    }
}