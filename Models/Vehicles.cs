using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Vehicles
    {
        [Key] 
        public int VehicleID { get; set; }
        public string VehicleType { get; set; } // Or enum
        public string LicensePlate { get; set; }
        public DateTime RegisterFrom { get; set; }
        public DateTime RegisterTo { get; set; }
        public bool IsActive { get; set; }

    }
}
