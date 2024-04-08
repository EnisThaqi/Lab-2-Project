using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : Controller
    {

        private LabContext _context;
        private readonly IMapper _mapper;

        public SubjectsController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddSubjects([FromBody] SubjectsDTO subjects)
        {
            if (subjects == null)
            {
                return BadRequest("Invalid subject data");
            }

            var newSubjects = _mapper.Map<Subjects>(subjects);

            _context.subjects.Add(newSubjects);
            await _context.SaveChangesAsync();


            return Ok();
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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSubjects(int id, [FromBody] SubjectsDTO updatedSubjectsDTO)
        {
            if (updatedSubjectsDTO == null || id != updatedSubjectsDTO.SubjectsID)
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
    }
}