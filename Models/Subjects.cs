using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Lab2.Models
{
    public class Subjects
    {
        [Key]
        public int SubjectID { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string BussinesNr { get; set; }
        [Required]
        [MaxLength(20)]
        public string VATnr { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Subject_TypeID { get; set; }

        [ForeignKey("Subject_TypeID")]

        public SubjectType subjectType { get; set; }
        public ICollection<UserSubjects> userSubjects { get; set; }
    }
}
