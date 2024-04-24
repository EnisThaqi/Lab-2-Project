using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.ModelsMongo;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab2.Controllers;

[ApiController]
[Route("[Controller]")]
public class TicketController : Controller
{
    private readonly MongoDBContext _mongoDBContext;
    private readonly LabContext _labContext;

    public TicketController(MongoDBContext mongoDBContext, LabContext labContext)
    {
        _mongoDBContext = mongoDBContext;
        _labContext = labContext;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateTicketAsync([FromBody] Ticket ticket)
    {
        var user = await _labContext.users.FindAsync(ticket.UserID);

        if (user == null)
        {
            return NotFound("User not found");
        }
        await _mongoDBContext.CreateTicketAsync(ticket);
        return CreatedAtAction(nameof(GetTicket), new { id = ticket.TicketID }, ticket);
    }

    [HttpGet("read")]
    public async Task<List<Ticket>> GetTicket()
    {
        return await _mongoDBContext.GetTicketAsync();
    }
    [HttpGet("read/{id}")]
    public async Task<IActionResult> GetTicket(string id)
    {
        var ticket = await _mongoDBContext.GetTicketByIDAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTicket(string id, [FromBody] Ticket ticket)
    {
        var update = Builders<Ticket>.Update

            .Set("Subject", ticket.Subject)
            .Set("Description", ticket.Description)
            .Set("Status", ticket.Status)
            .Set("CreatedAT", ticket.CreatedAt)
            .Set("UserID", ticket.UserID);

        await _mongoDBContext.UpdateTicketAsync(id, update);

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTicket(string ID)
    {
        await _mongoDBContext.DeleteTicketAsync(ID);
        return NoContent();
    }
}
