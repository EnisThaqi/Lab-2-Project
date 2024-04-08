using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class OrderStatus
    {
        [Key] 
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string description { get; set; }
    }
}
