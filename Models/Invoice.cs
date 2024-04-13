using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Required]
        public DateTime Issued_Date { get; set; }

        [Required]
        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int SubjectID { get; set; }

        [ForeignKey("SubjectID")]
        
        public Subjects subjects { get; set; }

        public ICollection<InvoiceOrders> invoiceOrders { get; set; }
        public ICollection<Payments> payments { get; set; }


    }
}