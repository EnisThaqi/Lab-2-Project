using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;

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
    }
}