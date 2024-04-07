namespace Lab2.DTOs
{
    public class UserDTO
    {
        public int? UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Created_At { get; set; }
        public int RoletID { get; set; }
    }
}
