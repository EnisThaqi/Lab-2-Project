using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Payments
    {
        [Key]
        public int PaymentsID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        [ForeignKey("PaymentMethods")]
        public int PaymentMethodsID { get; set; }
        public PaymentMethods PaymentMethods { get; set; }

        public bool Payed { get; set; }
    }
}