using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.ModelsMongo;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab2.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserNotificationsController : Controller
{
    private readonly MongoDBContext _mongoDBContext;
    private readonly LabContext _labContext;

    public UserNotificationsController(MongoDBContext mongoDBContext, LabContext labContext)
    {
        _mongoDBContext = mongoDBContext;
        _labContext = labContext;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateUserNotificationsAsync([FromBody] UserNotifications usernotifications)
    {
        var user = await _labContext.users.FindAsync(usernotifications.UserID);

        if (user == null)
        {
            return NotFound("User not found");
        }
        await _mongoDBContext.CreateUserNotificationsAsync(usernotifications);
        return CreatedAtAction(nameof(GetUserNotifications), new { id = usernotifications.UserNotificationsID }, usernotifications);
    }

    [HttpGet("read")]
    public async Task<List<UserNotifications>> GetUserNotifications()
    {
        return await _mongoDBContext.GetUserNotificationsAsync();
    }
    [HttpGet("read/{id}")]
    public async Task<IActionResult> GetUserNotifications(string id)
    {
        var usernotifications = await _mongoDBContext.GetUserNotificationsByIDAsync(id);
        if (usernotifications == null)
        {
            return NotFound();
        }
        return Ok(usernotifications);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUserNotifications(string id, [FromBody] UserNotifications usernotifications)
    {
        var update = Builders<UserNotifications>.Update
            .Set("Viewed", usernotifications.Viewed)
            .Set("Dismissed", usernotifications.Dismissed)
            .Set("UserID", usernotifications.UserID);

        await _mongoDBContext.UpdateUserNotificationsAsync(id, update);

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUserNotifications(string ID)
    {
        await _mongoDBContext.DeleteUserNotificationsAsync(ID);
        return NoContent();
    }
}