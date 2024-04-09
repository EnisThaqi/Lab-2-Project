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
    public class PackageSizesController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public PackageSizesController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePackageSize([FromBody] PackageSizesDTO packageSizeDto)
        {
            var packageSize = _mapper.Map<PackageSizes>(packageSizeDto);
            _context.Packagesizes.Add(packageSize);
            await _context.SaveChangesAsync();
            return Ok(packageSize);
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetPackageSizes(int id)
        {
            var GetPackageSizes = _context.Packagesizes.Find(id);



            if (GetPackageSizes == null)
            {
                return NotFound();
            }

            return Ok(GetPackageSizes);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePackageSize(int id, [FromBody] PackageSizesDTO packageSizeDto)
        {
            if (id != packageSizeDto.SizeID)
            {
                return BadRequest();
            }

            var packageSize = await _context.Packagesizes.FindAsync(id);
            if (packageSize == null)
            {
                return NotFound();
            }

            _mapper.Map(packageSizeDto, packageSize);
            await _context.SaveChangesAsync();
            return Ok(packageSize);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePackageSize(int id)
        {
            var packageSize = await _context.Packagesizes.FindAsync(id);
            if (packageSize == null)
            {
                return NotFound();
            }

            _context.Packagesizes.Remove(packageSize);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
