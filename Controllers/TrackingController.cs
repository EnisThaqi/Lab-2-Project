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
    public class TrackingController : Controller
    {
        private readonly MongoDBContext _mongoDBContext;

        public TrackingController(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTrackingAsync([FromBody] Tracking tracking)
        {
            await _mongoDBContext.CreateTrackingAsync(tracking);
            return CreatedAtAction(nameof(GetTrackingByID), new { id = tracking.TrackingID }, tracking);
        }

        [HttpGet("Read")]
        public async Task<List<Tracking>> GetTrackingAsync()
        {
            return await _mongoDBContext.GetTrackingAsync();
        }

        [HttpGet("Read/{id}")]
        public async Task<IActionResult> GetTrackingByID(string id)
        {
            var tracking = await _mongoDBContext.GetTrackingByIDAsync(id);
            if (tracking == null)
            {
                return NotFound();
            }
            return Ok(tracking);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTracking(string id, [FromBody] Tracking tracking)
        {
            var update = Builders<Tracking>.Update
                .Set("Status", tracking.Status)
                .Set("Location", tracking.Location)
                .Set("UpdatedAt", tracking.UpdatedAt)
                .Set("TrackNumber", tracking.TrackNumber)
                .Set("OrderID", tracking.OrderID);

            await _mongoDBContext.UpdateTrackingAsync(id, update);

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTracking(string id)
        {
            await _mongoDBContext.DeleteTrackingAsync(id);
            return NoContent();
        }
    }
}
