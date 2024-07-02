using AutoMapper;
using Lab2.DataService;
using Lab2.DTOs;
using Microsoft.AspNetCore.Mvc;

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


}
