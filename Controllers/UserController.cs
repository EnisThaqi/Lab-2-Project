using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private LabContext _context;
        private readonly IMapper _mapper;

        public UserController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            var newUser = _mapper.Map<User>(user);

            _context.users.Add(newUser);
            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetUser(int id)
        {
            var User = _context.users.Find(id);



            if (User == null)
            {
                return NotFound();
            }

            return Ok(User);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var User = await _context.users.ToListAsync();

            if (User == null || User.Count == 0)
            {
                return NotFound("No users found.");
            }

            var UserDTO = _mapper.Map<List<UserDTO>>(User);

            return Ok(UserDTO); 
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO updatedUserDTO)
        {
            if (updatedUserDTO == null || id != updatedUserDTO.UserID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingUser = _context.users.Find(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedUserDTO, existingUser);



            _context.users.Update(existingUser);
            await _context.SaveChangesAsync();

            return Ok(existingUser);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = _context.users.Find(id);

            if (User == null)
            {
                return NotFound();
            }

            _context.users.Remove(User);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            var existsingUsers = await _context.users.Where(u => u.Username == user.Username || u.Email == user.Email).ToListAsync();
            if (existsingUsers !=  null && existsingUsers.Any())
            {
                return BadRequest("User already exists");
            }

            var users = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                RoletID = 3
            };

            _context.users.Add(users);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid login data");
            }

            var User = await _context.users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (User == null)
            {
                return NotFound("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(user.Password, User.Password))
            {
                return BadRequest("Incorrect password");
            }

            var subjectId = await _context.user_subjects.Where(us => us.UserID == User.UserID).Select(us => us.SubjectID).FirstOrDefaultAsync();

            // Set up session or any other method for session management
            HttpContext.Session.SetString("UserUsername", user.Username);

            return Ok(new { Message = "Login successful", Role = User.RoletID, SubjectId = subjectId });
        }


    }
}