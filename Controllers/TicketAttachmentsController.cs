using Microsoft.AspNetCore.Mvc;
using Lab2.DataService;
using Lab2.ModelsMongo;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab2.Controllers;

[ApiController]
[Route("[Controller]")]
public class TicketAttachmentsController : Controller
{
    private readonly MongoDBContext _mongoDBContext;
   

    public TicketAttachmentsController(MongoDBContext mongoDBContext)
    {
        _mongoDBContext = mongoDBContext;
       
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post([FromBody] TicketAttachments ticketattachments)
    {
        await _mongoDBContext.CreateTicketAttachmentsAsync(ticketattachments);
        return CreatedAtAction(nameof(GetTicketAttachments), new { TicketAttachmentsID = ticketattachments.TicketAttachmentsID }, ticketattachments);
    }

    [HttpGet("read")]
    public async Task<List<TicketAttachments>> GetTicketAttachments()
    {
        return await _mongoDBContext.GetTicketAttachmentsAsync();
    }
    [HttpGet("read/{id}")]
    public async Task<IActionResult> GetTicketAttachments(string id)
    {
        var ticketattachments = await _mongoDBContext.GetTicketAttachmentsByIDAsync(id);
        if (ticketattachments == null)
        {
            return NotFound();
        }
        return Ok(ticketattachments);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> AddToTicketAttachments(string TicketAttachmentsID, byte[] File, string? Description,DateTime CreatedAt)
    {
        await _mongoDBContext. AddToTicketAttachmentsAsync(TicketAttachmentsID, File,  Description, CreatedAt);
        return NoContent();

    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTicketAttachments(string ID)
    {
        await _mongoDBContext.DeleteTicketAttachmentsAsync(ID);
        return NoContent();
    }
}
