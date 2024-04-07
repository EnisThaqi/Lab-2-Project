using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Rolet
    {
        [Key]
        public int RoletID { get; set; }
        public string Rolet_Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}