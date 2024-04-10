using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {

        private LabContext _context;
        private readonly IMapper _mapper;

        public OrdersController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddOrders([FromBody] OrdersDTO Orders)
        {
            if (Orders == null)
            {
                return BadRequest("Invalid user data");
            }

            var newOrders = _mapper.Map<Orders>(Orders);

            _context.orders.Add(newOrders);
            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetUser(int id)
        {
            var Orders = _context.orders.Find(id);



            if (User == null)
            {
                return NotFound();
            }

            return Ok(User);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOrders(int id, [FromBody] OrdersDTO updatedOrdersDTO)
        {
            if (updatedOrdersDTO == null || id != updatedOrdersDTO.OrderID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingOrders = _context.orders.Find(id);

            if (existingOrders == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedOrdersDTO, existingOrders);



            _context.orders.Update(existingOrders);
            await _context.SaveChangesAsync();

            return Ok(existingOrders);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var Orders = _context.orders.Find(id);

            if (Orders == null)
            {
                return NotFound();
            }

            _context.orders.Remove(Orders);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}