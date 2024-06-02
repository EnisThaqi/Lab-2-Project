using Lab2.DTOs;
using Lab2.Models;

namespace Lab2.DataService
{
    public class UserService
    {
            private readonly LabContext _context;

            public UserService(LabContext context)
            {
                _context = context;
            }

            public async Task CreateUserForSubjects(UserDTO userDTO, List<int> subjectIds)
            {
            var user = new User
            {
                // Map properties from userDTO
                Username = userDTO.Username,
                Email = userDTO.Email,
                Address = userDTO.Address,
                Password = userDTO.Password,
                PhoneNumber = userDTO.PhoneNumber,
                // Map other properties accordingly
                Created_At = DateTime.Now,
                RoletID = userDTO.RoletID ?? 5
            };

                _context.users.Add(user);
                await _context.SaveChangesAsync();

                // Associate the user with the specified subjects
                foreach (var subjectId in subjectIds)
                {
                    _context.user_subjects.Add(new UserSubjects
                    {
                        UserID = user.UserID,
                        SubjectID = subjectId
                    });
                }

                await _context.SaveChangesAsync();
            }
        }
}
