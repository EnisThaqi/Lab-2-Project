using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Routes
    {
        [Key]
        public int RouteId { get; set; }
        public decimal Distance { get; set; }
        public double Duration { get; set; }
        public bool optimal { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Orders Order { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }
        public Vehicles Vehicle { get; set; }
    }
}
