using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class PackageSizes
    {
        [Key]
        public int SizeID { get; set; }
         
        public string Size { get; set; }
    }
}
