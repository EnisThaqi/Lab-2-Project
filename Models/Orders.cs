using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        public string Receiver_Name { get; set; }

        public decimal Weight { get; set; }

        public string Receiver_Country { get; set; }

        public string Receiver_Phone { get; set; }

        public string Receiver_Address { get; set; }

        public string Description { get; set; }

        public string Additional_information { get; set; }

        [Required]
        [StringLength(100)]
        public string Reference_code { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool Can_open { get; set; } = false;

        public bool Is_take_back { get; set; } = false;

        [ForeignKey("PackageSize")]
        public int PackageSizeId { get; set; }
        public PackageSizes PackageSize { get; set; }

        [ForeignKey("OrderStatus")]
        public int StatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int SubjectID { get; set; }

        [ForeignKey("SubjectID")]

        public Subjects Subject { get; set; }
        public IList<Routes>? Routes { get; set; }
        public ICollection<InvoiceOrders> InvoiceOrders { get; set; }
         
    }
}
