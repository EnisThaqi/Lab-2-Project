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
    public class UserFeedbackController : Controller
    {
        private readonly MongoDBContext _mongoDBContext;
        private readonly LabContext _labContext;

        public UserFeedbackController(MongoDBContext mongoDBContext, LabContext labContext)
        {
            _mongoDBContext = mongoDBContext;
            _labContext = labContext;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUserFeedbackAsync([FromBody] UserFeedback userFeedback)
        {
            var user = await _labContext.users.FindAsync(userFeedback.UserID);

            if (user == null)
            {
                return NotFound("User not found");
            }
            await _mongoDBContext.CreateUserFeedbackAsync(userFeedback);
            return CreatedAtAction(nameof(GetUserFeedbackByID), new { id = userFeedback.FeedbackID }, userFeedback);
        }

        [HttpGet("Read")]
        public async Task<List<UserFeedback>> GetUserFeedbackAsync()
        {
            return await _mongoDBContext.GetUserFeedbackAsync();
        }

        [HttpGet("Read/{id}")]
        public async Task<IActionResult> GetUserFeedbackByID(string id)
        {
            var userFeedback = await _mongoDBContext.GetUserFeedbackByIDAsync(id);
            if (userFeedback == null)
            {
                return NotFound();
            }
            return Ok(userFeedback);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUserFeedback(string id, [FromBody] UserFeedback userFeedback)
        {
            var update = Builders<UserFeedback>.Update
                .Set("FeedbackText", userFeedback.FeedbackText)
                .Set("FeedbackDate", userFeedback.FeedbackDate)
                .Set("UserID", userFeedback.UserID);

            await _mongoDBContext.UpdateUserFeedbackAsync(id, update);

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUserFeedback(string id)
        {
            await _mongoDBContext.DeleteUserFeedbackAsync(id);
            return NoContent();
        }
    }
}
