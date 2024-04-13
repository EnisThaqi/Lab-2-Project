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
    public class PaymentsController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public PaymentsController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddPayment([FromBody] PaymentsDTO paymentDTO)
        {
            if (paymentDTO == null)
            {
                return BadRequest("Invalid payment data");
            }

            var newPayment = _mapper.Map<Payments>(paymentDTO);

            _context.payments.Add(newPayment);
            await _context.SaveChangesAsync();

            return Ok(newPayment);
        }

        [HttpGet("read/{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var payment = await _context.payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] PaymentsDTO updatedPaymentDTO)
        {
            if (updatedPaymentDTO == null || id != updatedPaymentDTO.PaymentsID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingPayment = await _context.payments.FindAsync(id);

            if (existingPayment == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedPaymentDTO, existingPayment);

            _context.payments.Update(existingPayment);
            await _context.SaveChangesAsync();

            return Ok(existingPayment);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            _context.payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _context.payments.ToListAsync();
            var paymentDTOs = _mapper.Map<List<PaymentsDTO>>(payments);

            return Ok(paymentDTOs);
        }
    }
}
