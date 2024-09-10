using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;

namespace Dern_Support_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuote _quoteRepository;

        public QuotesController(IQuote quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            var quotes = await _quoteRepository.GetAllQuotesAsync();
            if (quotes == null || !quotes.Any())
            {
                return NotFound();
            }
            return Ok(quotes);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            var quote = await _quoteRepository.GetQuoteByIdAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, QuoteDto quoteDto)
        {
            if (id != quoteDto.QuoteId)
            {
                return BadRequest("Quote ID mismatch.");
            }

            try
            {
                var updatedQuote = await _quoteRepository.UpdateQuoteAsync(quoteDto, id);
                if (updatedQuote == null)
                {
                    return NotFound($"Quote with ID {id} not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Quotes
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(QuoteDto quoteDto)
        {
            if (quoteDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdQuote = await _quoteRepository.AddQuoteAsync(quoteDto);
            if (createdQuote == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating quote.");
            }

            return CreatedAtAction(nameof(GetQuote), new { id = createdQuote.QuoteId }, createdQuote);
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            try
            {
                await _quoteRepository.DeleteQuoteAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
