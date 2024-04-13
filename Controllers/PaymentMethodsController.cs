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
    public class PaymentMethodsController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IMapper _mapper;

        public PaymentMethodsController(LabContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddPaymentMethod([FromBody] PaymentMethodsDTO paymentMethodDTO)
        {
            if (paymentMethodDTO == null)
            {
                return BadRequest("Invalid payment method data");
            }

            var newPaymentMethod = _mapper.Map<PaymentMethods>(paymentMethodDTO);

            _context.paymentmethods.Add(newPaymentMethod);
            await _context.SaveChangesAsync();

            return Ok(newPaymentMethod);
        }

        [HttpGet("read/{id}")]
        public async Task<IActionResult> GetPaymentMethod(int id)
        {
            var paymentMethod = await _context.paymentmethods.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return Ok(paymentMethod);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePaymentMethod(int id, [FromBody] PaymentMethodsDTO updatedPaymentMethodDTO)
        {
            if (updatedPaymentMethodDTO == null || id != updatedPaymentMethodDTO.PaymentMethodsID)
            {
                return BadRequest("Invalid data or mismatched id");
            }

            var existingPaymentMethod = await _context.paymentmethods.FindAsync(id);

            if (existingPaymentMethod == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedPaymentMethodDTO, existingPaymentMethod);

            _context.paymentmethods.Update(existingPaymentMethod);
            await _context.SaveChangesAsync();

            return Ok(existingPaymentMethod);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            var paymentMethod = await _context.paymentmethods.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            _context.paymentmethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            var paymentMethods = await _context.paymentmethods.ToListAsync();
            var paymentMethodDTOs = _mapper.Map<List<PaymentMethodsDTO>>(paymentMethods);

            return Ok(paymentMethodDTOs);
        }
    }
}
