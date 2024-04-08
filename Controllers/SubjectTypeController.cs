using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectTypeController : Controller
    {

        private LabContext _context;
        private readonly IMapper _mapper;

        public SubjectTypeController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddSubjectType([FromBody] SubjectTypeDTO subjectType)
        {
            if (subjectType == null)
            {
                return BadRequest("Invalid subjectType data");
            }

            var newSubjectType = _mapper.Map<SubjectType>(subjectType);

            _context.subject_type.Add(newSubjectType);
            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetSubjectType(int id)
        {
            var SubjectType = _context.subject_type.Find(id);



            if (SubjectType == null)
            {
                return NotFound();
            }

            return Ok(SubjectType);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSubjectType(int id, [FromBody] SubjectTypeDTO updatedSubjectTypeDTO)
        {
            if (updatedSubjectTypeDTO == null || id != updatedSubjectTypeDTO.Subject_TypeID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingSubjectType = _context.subject_type.Find(id);

            if (existingSubjectType == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedSubjectTypeDTO, existingSubjectType);



            _context.subject_type.Update(existingSubjectType);
            await _context.SaveChangesAsync();

            return Ok(existingSubjectType);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubjectType(int id)
        {
            var SubjectType = _context.subject_type.Find(id);

            if (SubjectType == null)
            {
                return NotFound();
            }

            _context.subject_type.Remove(SubjectType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}