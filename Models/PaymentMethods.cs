using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class PaymentMethods
    {
        [Key]
        public int PaymentMethodsID { get; set; }

        [Required]
        public string MethodName { get; set; }

        public ICollection<Payments> payments { get; set; }

    }
}
