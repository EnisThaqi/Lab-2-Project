using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Lab2.DataService;
using Lab2.ModelsMongo;

namespace Lab2.Controllers;

[Controller]
[Route("[controller]")]
public class NotificationsTypeController : Controller
{
    private readonly MongoDBContext _mongoDBContext;

    public NotificationsTypeController(MongoDBContext mongoDBContext)
    {
        _mongoDBContext = mongoDBContext;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post([FromBody] NotificationsType notificationsType)
    {
        await _mongoDBContext.CreateAsync(notificationsType);
        return CreatedAtAction(nameof(Get), new { NotificationsTypeID = notificationsType.NotificationsTypeID }, notificationsType);
    }

    [HttpGet("read")]
    public async Task<List<NotificationsType>> Get() 
    {
        return await _mongoDBContext.GetAsync();
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> AddToNotificationsType(string NotificationsTypeID, string? TypeName) 
    {
        await _mongoDBContext.AddToNotificationsTypeAsync(NotificationsTypeID, TypeName);
        return NoContent();
    
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(string NotificationsTypeID) 
    { 
        await _mongoDBContext.DeleteAsync(NotificationsTypeID);
        return NoContent();
    }
}
