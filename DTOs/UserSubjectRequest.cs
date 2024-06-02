namespace Lab2.DTOs
{
    public class UserSubjectRequest
    {
        public UserDTO User { get; set; }
        public List<int> SubjectIds { get; set; }
    }
}
