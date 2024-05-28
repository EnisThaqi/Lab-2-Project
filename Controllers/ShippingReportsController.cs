using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.ModelsMongo;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ShippingReportController : Controller
    {
        private readonly MongoDBContext _mongoDBContext;
        private readonly LabContext _labContext;

        public ShippingReportController(MongoDBContext mongoDBContext, LabContext labContext)
        {
            _mongoDBContext = mongoDBContext;
            _labContext = labContext;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateShippingReportAsync([FromBody] ShippingReport shippingReport)
        {
            var user = await _labContext.users.FindAsync(shippingReport.UserID);

            if (user == null)
            {
                return NotFound("User not found");
            }
            await _mongoDBContext.CreateShippingReportAsync(shippingReport);
            return CreatedAtAction(nameof(GetShippingReportByID), new { id = shippingReport.ReportID }, shippingReport);
        }

        [HttpGet("Read")]
        public async Task<List<ShippingReport>> GetShippingReportAsync()
        {
            return await _mongoDBContext.GetShippingReportAsync();
        }

        [HttpGet("Read/{id}")]
        public async Task<IActionResult> GetShippingReportByID(string id)
        {
            var shippingReport = await _mongoDBContext.GetShippingReportByIDAsync(id);
            if (shippingReport == null)
            {
                return NotFound();
            }
            return Ok(shippingReport);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateShippingReport(string id, [FromBody] ShippingReport shippingReport)
        {
            var update = Builders<ShippingReport>.Update
                .Set("DeliveryTime", shippingReport.DeliveryTime)
                .Set("DeliveryDate", shippingReport.DeliveryDate)
                .Set("Status", shippingReport.Status)
                .Set("UserID", shippingReport.UserID);

            await _mongoDBContext.UpdateShippingReportAsync(id, update);

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteShippingReport(string id)
        {
            await _mongoDBContext.DeleteShippingReportAsync(id);
            return NoContent();
        }
    }
}
