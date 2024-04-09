using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Lab2.Models
{
    public class UserSubjects
    {
        public int UserID { get; set; }
        public int SubjectID { get; set; }

        [ForeignKey("UserID")]
        public User user { get; set; }

        [ForeignKey("SubjectID")]
        public Subjects subjects { get; set; }
    }
}
