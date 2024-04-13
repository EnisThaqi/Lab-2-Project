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
    public class VehiclesController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public VehiclesController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVehicles([FromBody] VehiclesDTO vehiclesDto)
        {
            var vehicles = _mapper.Map<Vehicles>(vehiclesDto);
            _context.Vehicles.Add(vehicles);
            await _context.SaveChangesAsync();
            return Ok(vehicles);
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetVehicles(int id)
        {
            var GetVehicles = _context.Vehicles.Find(id);



            if (GetVehicles == null)
            {
                return NotFound();
            }

            return Ok(GetVehicles);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateVehicles(int id, [FromBody] VehiclesDTO vehiclesDto)
        {
            if (id != vehiclesDto.VehicleID)
            {
                return BadRequest();
            }

            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            _mapper.Map(vehiclesDto, vehicles);
            await _context.SaveChangesAsync();
            return Ok(vehicles);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVehicles(int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

