using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Routes
    {
        [Key]
        public int RouteId { get; set; }
        public decimal Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public bool optimal { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        public Orders orders { get; set; }


        [ForeignKey("Vehicles")]
        public int VehiclesID { get; set; }
        public Vehicles vehicles { get; set; }


    }
}
