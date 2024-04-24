using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.ModelsMongo;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab2.Controllers;

[ApiController]
[Route("[Controller]")]
public class TicketCommentsController : Controller
{
    private readonly MongoDBContext _mongoDBContext;
    private readonly LabContext _labContext;

    public TicketCommentsController(MongoDBContext mongoDBContext, LabContext labContext)
    {
        _mongoDBContext = mongoDBContext;
        _labContext = labContext;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateTicketCommentsAsync([FromBody] TicketComments ticketcomments)
    {
        var user = await _labContext.users.FindAsync(ticketcomments.UserID);

        if (user == null)
        {
            return NotFound("User not found");
        }
        await _mongoDBContext.CreateTicketCommentsAsync(ticketcomments);
        return CreatedAtAction(nameof(GetTicketComments), new { id = ticketcomments.TicketCommentsID }, ticketcomments);
    }

    [HttpGet("read")]
    public async Task<List<TicketComments>> GetTicketComments()
    {
        return await _mongoDBContext.GetTicketCommentsAsync();
    }
    [HttpGet("read/{id}")]
    public async Task<IActionResult> GetTicketComments(string id)
    {
        var ticketcomments = await _mongoDBContext.GetTicketCommentsByIDAsync(id);
        if (ticketcomments == null)
        {
            return NotFound();
        }
        return Ok(ticketcomments);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTicketComments(string id, [FromBody] TicketComments ticketcomments)
    {
        var update = Builders<TicketComments>.Update
           
            .Set("Comment", ticketcomments.Comment)
            .Set("CreatedAT", ticketcomments.CreatedAt)
            .Set("UserID", ticketcomments.UserID)
            .Set("TicketID", ticketcomments.TicketID);

        await _mongoDBContext.UpdateTicketCommentsAsync(id, update);

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTicketComments(string ID)
    {
        await _mongoDBContext.DeleteTicketCommentsAsync(ID);
        return NoContent();
    }
}
