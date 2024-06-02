using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : Controller
    {

        private LabContext _context;
        private readonly IMapper _mapper;
        private UserService _userService;

        public SubjectsController(LabContext context, IMapper mapper, UserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        

        [HttpGet("Read/{id}")]
        public IActionResult GetSubjects(int id)
        {
            var Subjects = _context.subjects.Find(id);



            if (Subjects == null)
            {
                return NotFound();
            }

            return Ok(Subjects);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _context.subjects.ToListAsync(); // Use ToListAsync for async fetching

            if (subjects == null || subjects.Count == 0) // Check for empty results
            {
                return NotFound("No subjects found.");
            }

            var SubjectsDTO = _mapper.Map<List<SubjectsDTO>>(subjects); // Correct mapping

            return Ok(SubjectsDTO); // Return mapped DTOs with 200 OK
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSubjects(int id, [FromBody] SubjectsDTO updatedSubjectsDTO)
        {
            if (updatedSubjectsDTO == null || id != updatedSubjectsDTO.SubjectID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingSubjects = _context.subjects.Find(id);

            if (existingSubjects == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedSubjectsDTO, existingSubjects);



            _context.subjects.Update(existingSubjects);
            await _context.SaveChangesAsync();

            return Ok(existingSubjects);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubjects(int id)
        {
            var Subjects = _context.subjects.Find(id);

            if (Subjects == null)
            {
                return NotFound();
            }

            _context.subjects.Remove(Subjects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectsDTO subjects)
        {
            if (subjects == null)
            {
                return BadRequest("Invalid subject data");
            }

            var newSubjects = _mapper.Map<Subjects>(subjects);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("12345678");

            _context.subjects.Add(newSubjects);
            await _context.SaveChangesAsync();

            
            var user = new UserDTO
            {
                Username = $"UserForSubject{newSubjects.SubjectID}",
                Email = $"subject{newSubjects.SubjectID}@example.com",
                Address = "Default Address",
                Password = hashedPassword,
                PhoneNumber = "Default Number",


            };


            var userSubjectRequest = new UserSubjectRequest
            {
                User = user,
                SubjectIds = new List<int> { newSubjects.SubjectID }
            };

            await _userService.CreateUserForSubjects(userSubjectRequest.User, userSubjectRequest.SubjectIds);

            return Ok(newSubjects);
        }
    }
}