using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class InvoiceOrders
    {
        [Key]
        public int InvoiceOrderId { get; set; } // Primary key property

        [ForeignKey("InvoiceID")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        [ForeignKey("OrderID")]
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
    }
}
