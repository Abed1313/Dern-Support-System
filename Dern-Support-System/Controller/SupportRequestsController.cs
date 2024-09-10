using Dern_Support_System.Models.DTO;
using Dern_Support_System.Models;
using Dern_Support_System.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SupportRequestsController : ControllerBase
{
    private readonly ISupportRequest _context;

    public SupportRequestsController(ISupportRequest supportRequestService)
    {
        _context = supportRequestService;
    }

    // GET: api/SupportRequests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupportRequest>>> GetSupportRequests()
    {
        var supportRequests = await _context.GetAllSupportRequestsAsync();
        if (supportRequests == null)
        {
            return NotFound();
        }
        return Ok(supportRequests);
    }

    // GET: api/SupportRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SupportRequest>> GetSupportRequest(int id)
    {
        var supportRequest = await _context.GetSupportRequestByIdAsync(id);
        if (supportRequest == null)
        {
            return NotFound();
        }

        return Ok(supportRequest);
    }

    // PUT: api/SupportRequests/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSupportRequest(int id, SupportRequestDto supportRequestDto)
    {
        if (id != supportRequestDto.SupportRequestId)
        {
            return BadRequest("Support Request ID mismatch.");
        }

        try
        {
            var updatedRequest = await _context.UpdateSupportRequestAsync(supportRequestDto, id);
            if (updatedRequest == null)
            {
                return NotFound($"Support Request with ID {id} not found.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return NoContent();
    }

    // POST: api/SupportRequests
    [HttpPost("post")]
    public async Task<ActionResult<SupportRequest>> PostSupportRequest(SupportRequestDto supportRequestDto)
    {
        var supportRequest = await _context.AddSupportRequestAsync(supportRequestDto);
        if (supportRequest == null)
        {
            return Problem("Error creating the support request.");
        }

        return CreatedAtAction("GetSupportRequest", new { id = supportRequest.SupportRequestId }, supportRequest);
    }

    // DELETE: api/SupportRequests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupportRequest(int id)
    {
        try
        {
            await _context.DeleteSupportRequestAsync(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return NoContent();
    }
}
