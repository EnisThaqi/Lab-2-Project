using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoletController : Controller
    {

        private LabContext _context;
        private readonly IMapper _mapper;

        public RoletController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddRolet([FromBody] RoletDTO rolet)
        {
            if (rolet == null)
            {
                return BadRequest("Invalid role data");
            }

            var newRolet = _mapper.Map<Rolet>(rolet);

            _context.roles.Add(newRolet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetRolet(int id)
        {
            var rolet = _context.roles.Find(id);



            if (rolet == null)
            {
                return NotFound();
            }

            return Ok(rolet);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateRolet(int id, [FromBody] RoletDTO updatedRoletDTO)
        {
            if (updatedRoletDTO == null || id != updatedRoletDTO.RoletID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingRolet = _context.roles.Find(id);

            if (existingRolet == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedRoletDTO, existingRolet);



            _context.roles.Update(existingRolet);
            await _context.SaveChangesAsync();

            return Ok(existingRolet);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRolet(int id)
        {
            var rolet = _context.roles.Find(id);

            if (rolet == null)
            {
                return NotFound();
            }

            _context.roles.Remove(rolet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}