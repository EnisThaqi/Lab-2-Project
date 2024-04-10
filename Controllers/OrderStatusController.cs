using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderStausController : Controller
    {

        private LabContext _context;
        private readonly IMapper _mapper;

        public OrderStausController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddOrderStatus([FromBody] OrderStatusDTO orderstatus)
        {
            if (orderstatus == null)
            {
                return BadRequest("Invalid data");
            }

            var newOrderStatus = _mapper.Map<OrderStatus>(orderstatus);

            _context.orderstatus.Add(newOrderStatus);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("Read/{id}")]
        public IActionResult GetOrderStatus(int id)
        {
            var orderstatus = _context.orderstatus.Find(id);



            if (orderstatus == null)
            {
                return NotFound();
            }

            return Ok(orderstatus);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderStatusDTO updatedOrderStatusDTO)
        {
            if (updatedOrderStatusDTO == null || id != updatedOrderStatusDTO.StatusId)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingOrderStatus = _context.orderstatus.Find(id);

            if (existingOrderStatus == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedOrderStatusDTO, existingOrderStatus);



            _context.orderstatus.Update(existingOrderStatus);
            await _context.SaveChangesAsync();

            return Ok(existingOrderStatus);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrderStatus(int id)
        {
            var orderstatus = _context.orderstatus.Find(id);

            if (orderstatus == null)
            {
                return NotFound();
            }

            _context.orderstatus.Remove(orderstatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}