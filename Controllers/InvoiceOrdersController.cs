using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceOrdersController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public InvoiceOrdersController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddInvoiceOrder([FromBody] InvoiceOrderDTO invoiceOrderDTO)
        {
            if (invoiceOrderDTO == null)
            {
                return BadRequest("Invalid invoice order data");
            }

            var newInvoiceOrder = _mapper.Map<InvoiceOrders>(invoiceOrderDTO);

            _context.invoiceorders.Add(newInvoiceOrder);
            await _context.SaveChangesAsync();

            return Ok(newInvoiceOrder);
        }

        [HttpGet("read/{invoiceId}/{orderId}")]
        public async Task<IActionResult> GetInvoiceOrder(int invoiceId, int orderId)
        {
            var invoiceOrder = await _context.invoiceorders.FindAsync(invoiceId, orderId);

            if (invoiceOrder == null)
            {
                return NotFound();
            }

            return Ok(invoiceOrder);
        }

        [HttpPut("update/{invoiceId}/{orderId}")]
        public async Task<IActionResult> UpdateInvoiceOrder(int invoiceId, int orderId, [FromBody] InvoiceOrderDTO updatedInvoiceOrderDTO)
        {
            if (updatedInvoiceOrderDTO == null || invoiceId != updatedInvoiceOrderDTO.InvoiceId || orderId != updatedInvoiceOrderDTO.OrderId)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingInvoiceOrder = await _context.invoiceorders.FindAsync(invoiceId, orderId);

            if (existingInvoiceOrder == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedInvoiceOrderDTO, existingInvoiceOrder);

            _context.invoiceorders.Update(existingInvoiceOrder);
            await _context.SaveChangesAsync();

            return Ok(existingInvoiceOrder);
        }

        [HttpDelete("delete/{invoiceId}/{orderId}")]
        public async Task<IActionResult> DeleteInvoiceOrder(int invoiceId, int orderId)
        {
            var invoiceOrder = await _context.invoiceorders.FindAsync(invoiceId, orderId);

            if (invoiceOrder == null)
            {
                return NotFound();
            }

            _context.invoiceorders.Remove(invoiceOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInvoiceOrders()
        {
            var invoiceOrders = await _context.invoiceorders.ToListAsync();
            var invoiceOrderDTOs = _mapper.Map<List<InvoiceOrderDTO>>(invoiceOrders);

            return Ok(invoiceOrderDTOs);
        }
    }
}
