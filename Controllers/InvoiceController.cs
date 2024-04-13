using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.DTOs;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public InvoiceController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO == null)
            {
                return BadRequest("Invalid invoice data");
            }

            var newInvoice = _mapper.Map<Invoice>(invoiceDTO);

            _context.invoices.Add(newInvoice);
            await _context.SaveChangesAsync();

            return Ok(newInvoice);
        }

        [HttpGet("read/{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var invoice = await _context.invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceDTO updatedInvoiceDTO)
        {
            if (updatedInvoiceDTO == null || id != updatedInvoiceDTO.InvoiceID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingInvoice = await _context.invoices.FindAsync(id);

            if (existingInvoice == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedInvoiceDTO, existingInvoice);

            _context.invoices.Update(existingInvoice);
            await _context.SaveChangesAsync();

            return Ok(existingInvoice);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            _context.invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _context.invoices.ToListAsync();
            var invoiceDTOs = _mapper.Map<List<InvoiceDTO>>(invoices);

            return Ok(invoiceDTOs);
        }
    }
}
