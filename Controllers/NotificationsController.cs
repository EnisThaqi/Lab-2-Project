using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.ModelsMongo;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab2.Controllers;

[ApiController]
[Route("[Controller]")]
public class NotificationsController : Controller
{
    private readonly MongoDBContext _mongoDBContext;
    private readonly LabContext _labContext;

    public NotificationsController(MongoDBContext mongoDBContext, LabContext labContext)
    {
        _mongoDBContext = mongoDBContext;
        _labContext = labContext;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNotificationsAsync([FromBody] Notifications notifications)
    {
        var user = await _labContext.users.FindAsync(notifications.UserID);
        
        if (user == null)
        {
            return NotFound("User not found");
        }
        await _mongoDBContext.CreateNotificationsAsync(notifications);
        return CreatedAtAction(nameof(GetNotifications), new { id = notifications.NotificationsID }, notifications);
    }

    [HttpGet("read")]
    public async Task<List<Notifications>> GetNotifications()
    {
        return await _mongoDBContext.GetNotificationsAsync();
    }
    [HttpGet("read/{id}")]
    public async Task<IActionResult> GetNotifications(string id)
    {
        var notifications = await _mongoDBContext.GetNotificationsByIDAsync(id);
        if (notifications == null)
        {
            return NotFound();
        }
        return Ok(notifications);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateNotifications(string id, [FromBody] Notifications notifications)
    {
        var update = Builders<Notifications>.Update
            .Set("Message", notifications.Message)
            .Set("CreatedAT", notifications.CreatedAt)
            .Set("UserID", notifications.UserID);

        await _mongoDBContext.UpdateNotificationsAsync(id, update);

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteNotifications(string ID)
    {
        await _mongoDBContext.DeleteNotificationsAsync(ID);
        return NoContent();
    }
}
