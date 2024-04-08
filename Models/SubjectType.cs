using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class SubjectType
    {
        [Key]
        public int Subject_TypeID { get; set; }
        public string Subject_TypeDescription { get; set; }
        public ICollection<Subjects> subjects { get; set; }

    }
}