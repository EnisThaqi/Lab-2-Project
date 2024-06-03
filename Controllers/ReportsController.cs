using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Lab2.DataService;
using Lab2.Models;
using Lab2.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly LabContext _context;

        public ReportsController(LabContext context)
        {
            _context = context;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateReport([FromBody] ReportCriteriaDTO criteria)
        {
            var reportData = await GetReportDataAsync(criteria);
            return Ok(reportData);
        }

        private async Task<List<ReportDataDTO>> GetReportDataAsync(ReportCriteriaDTO criteria)
        {
            var query = _context.orders.AsQueryable(); 

            if (criteria.StartDate.HasValue)
                query = query.Where(o => o.CreatedAt >= criteria.StartDate.Value);

            if (criteria.EndDate.HasValue)
                query = query.Where(o => o.CreatedAt <= criteria.EndDate.Value);

            if (!string.IsNullOrEmpty(criteria.ReceiverName))
                query = query.Where(o => o.Receiver_Name.Contains(criteria.ReceiverName));

            if (!string.IsNullOrEmpty(criteria.OrderStatus))
                query = query.Where(o => o.OrderStatus.Status == criteria.OrderStatus);

            var result = await query.ToListAsync();

            return result.Select(o => new ReportDataDTO
            {
                OrderID = o.OrderID,
                Quantity = o.Quantity,
                ReceiverName = o.Receiver_Name,    
                Weight = o.Weight,
                ReceiverCountry = o.Receiver_Country, 
                ReferenceCode = o.Reference_code,   
                CreatedAt = o.CreatedAt,
                OrderStatus = o.OrderStatus.Status 
            }).ToList();
        }
    }
}
