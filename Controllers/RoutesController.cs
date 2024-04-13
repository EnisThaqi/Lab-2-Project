using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public RoutesController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRoutes([FromBody] RoutesDTO routesDto)
        {
            var routes = _mapper.Map<Routes>(routesDto);
            await _context.routes.AddAsync(routes);
            await _context.SaveChangesAsync();
            return Ok(routes);
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetRoutes(int id)
        {
            var GetRoutes = _context.routes.Find(id);



            if (GetRoutes == null)
            {
                return NotFound();
            }

            return Ok(GetRoutes);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateRoutes(int id, [FromBody] RoutesDTO routesDto)
        {
            if (id != routesDto.RouteId)
            {
                return BadRequest();
            }

            var routes = await _context.routes.FindAsync(id);
            if (routes == null)
            {
                return NotFound();
            }

            _mapper.Map(routesDto, routes);
            await _context.SaveChangesAsync();
            return Ok(routes);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRoutes(int id)
        {
            var routes = await _context.routes.FindAsync(id);
            if (routes == null)
            {
                return NotFound();
            }

            _context.routes.Remove(routes);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}