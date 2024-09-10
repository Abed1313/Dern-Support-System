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
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedback _feedbackRepository;

        public FeedbacksController(IFeedback feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacksAsync();
            if (feedbacks == null || !feedbacks.Any())
            {
                return NotFound();
            }
            return Ok(feedbacks);
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        // PUT: api/Feedbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedbackAsync(int id, FeedbackDto feedbackDto)
        {
            if (id != feedbackDto.FeedbackId)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            try
            {
                var updatedFeedback = await _feedbackRepository.UpdateFeedbackAsync(feedbackDto, id);
                if (updatedFeedback == null)
                {
                    return NotFound($"Feedback with ID {id} not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Feedbacks
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(FeedbackDto feedbackDto)
        {
            if (feedbackDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdFeedback = await _feedbackRepository.AddFeedbackAsync(feedbackDto);
            if (createdFeedback == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating feedback.");
            }

            return CreatedAtAction(nameof(GetFeedback), new { id = createdFeedback.FeedbackId }, createdFeedback);
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                await _feedbackRepository.DeleteFeedbackAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
