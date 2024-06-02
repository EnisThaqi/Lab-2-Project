using Lab2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.DTOs
{
    public class OrdersDTO
    {
        public int OrderID { get; set; }
        
        public int quantity { get; set; } = 1;
    
        public string Receiver_Name { get; set; }
        public decimal Weight { get; set; }
        public string Receiver_Country { get; set; }
        public string Receiver_Phone { get; set; }
        public string Receiver_address { get; set; }
        public string Description { get; set; }
        public string Additional_information { get; set; }
       
        public string Reference_code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Can_open { get; set; } = false;
        public bool Is_take_back { get; set; } = false;


        
        public int PackageSizeId { get; set; }
       


       
        public int StatusId{ get; set; }
        public int SubjectID { get; set; }

    }
}
