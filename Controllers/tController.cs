using AutoMapper;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models.PlanetSatelliteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
 //geti per krejt librat me emer tautorit qe fillon me A te lidhja njo me shum

[Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public BookController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Book
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.Name.StartsWith("A"))
                .ToListAsync();

            var booksDto = _mapper.Map<List<BookDto>>(books);
            return Ok(booksDto);
        }
    }

    //shum me shum 
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Where(b => b.BookAuthors.Any(ba => ba.Author.Name.StartsWith("A")))
                .ToListAsync();

            var booksDto = _mapper.Map<List<BookDto>>(books);
            return Ok(booksDto);
        }
    }

    // njo me njo
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author) // Include author details
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }
    }
    //detyra planet satelit pa dto
    //A)
    [HttpPost]
    public async Task<ActionResult<Planet>> PostPlanet(Planet planet)
    {
        _context.Planets.Add(planet);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetPlanet", new { id = planet.PlanetID }, planet);
    }
    //B)
    [HttpPost]
    public async Task<ActionResult<Satellite>> PostSatellite(Satellite satellite)
    {
        _context.Satellites.Add(satellite);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetSatellite", new { id = satellite.SatelliteID }, satellite);
    }
    //C)
    [HttpPut("name/{name}")]
    public async Task<IActionResult> PutPlanetByName(string name, [FromBody] string newType)
    {
        var planet = await _context.Planets.FirstOrDefaultAsync(p => p.Name == name);
        if (planet == null)
        {
            return NotFound();
        }

        planet.Type = newType;
        _context.Entry(planet).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    //D)
    [HttpGet("planetName/{name}")]
    public async Task<ActionResult<IEnumerable<Satellite>>> GetSatellitesByPlanetName(string name)
    {
        var planet = await _context.Planets.FirstOrDefaultAsync(p => p.Name == name);
        if (planet == null)
        {
            return NotFound();
        }

        var satellites = await _context.Satellites
            .Where(s => s.PlanetID == planet.PlanetID && !s.IsDeleted)
            .ToListAsync();

        return Ok(satellites);
    }
    //E)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSatellite(int id)
    {
        var satellite = await _context.Satellites.FindAsync(id);
        if (satellite == null)
        {
            return NotFound();
        }

        satellite.IsDeleted = true;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    //detyra planet satelit me dto
    //planeti i pari
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly SpaceContext _context;
        private readonly IMapper _mapper;

        public PlanetsController(SpaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //A)
        [HttpPost]
        public async Task<ActionResult<PlanetDTO>> AddPlanet(PlanetDTO planetDTO)
        {
            var planet = _mapper.Map<Planet>(planetDTO);
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlanet), new { id = planet.PlanetId }, _mapper.Map<PlanetDTO>(planet));
        }
        //C)
        [HttpPut("{name}")]
        public async Task<IActionResult> UpdatePlanetType(string name, [FromBody] string newType)
        {
            var planet = await _context.Planets.FirstOrDefaultAsync(p => p.Name == name && !p.IsDeleted);
            if (planet == null)
            {
                return NotFound();
            }

            planet.Type = newType;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //D)
        [HttpGet("{name}/satellites")]
        public async Task<ActionResult<IEnumerable<SatelliteDTO>>> GetSatellitesByPlanetName(string name)
        {
            var planet = await _context.Planets.Include(p => p.Satellites)
                                               .FirstOrDefaultAsync(p => p.Name == name && !p.IsDeleted);

            if (planet == null)
            {
                return NotFound();
            }

            var satellites = planet.Satellites.Where(s => !s.IsDeleted).ToList();
            return Ok(_mapper.Map<IEnumerable<SatelliteDTO>>(satellites));
        }
    }
    //Sateliti
    [ApiController]
    [Route("api/[controller]")]
    public class SatellitesController : ControllerBase
    {
        private readonly SpaceContext _context;
        private readonly IMapper _mapper;

        public SatellitesController(SpaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //B)
        [HttpPost]
        public async Task<ActionResult<SatelliteDTO>> AddSatellite(SatelliteDTO satelliteDTO)
        {
            var satellite = _mapper.Map<Satellite>(satelliteDTO);
            _context.Satellites.Add(satellite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSatellite), new { id = satellite.SatelliteId }, _mapper.Map<SatelliteDTO>(satellite));
        }
        //E)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatellite(int id)
        {
            var satellite = await _context.Satellites.FindAsync(id);
            if (satellite == null)
            {
                return NotFound();
            }

            satellite.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
