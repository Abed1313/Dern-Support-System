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
    public class RepairJobsController : ControllerBase
    {
        private readonly IRepairJob _repairJobRepository;

        public RepairJobsController(IRepairJob repairJobRepository)
        {
            _repairJobRepository = repairJobRepository;
        }

        // GET: api/RepairJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairJob>>> GetRepairJobs()
        {
            var repairJobs = await _repairJobRepository.GetAllRepairJobsAsync();
            if (repairJobs == null || !repairJobs.Any())
            {
                return NotFound();
            }
            return Ok(repairJobs);
        }

        // GET: api/RepairJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairJob>> GetRepairJob(int id)
        {
            var repairJob = await _repairJobRepository.GetRepairJobByIdAsync(id);
            if (repairJob == null)
            {
                return NotFound();
            }
            return Ok(repairJob);
        }

        // PUT: api/RepairJobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairJob(int id, RepairJobDto repairJobDto)
        {
            if (id != repairJobDto.RepairJobId)
            {
                return BadRequest();
            }

            try
            {
                var updatedRepairJob = await _repairJobRepository.UpdateRepairJobAsync(repairJobDto, id);
                if (updatedRepairJob == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/RepairJobs
        [HttpPost]
        public async Task<ActionResult<RepairJob>> PostRepairJob(RepairJobDto repairJobDto)
        {
            if (repairJobDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var repairJob = await _repairJobRepository.AddRepairJobAsync(repairJobDto);
            if (repairJob == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating repair job.");
            }

            return CreatedAtAction(nameof(GetRepairJob), new { id = repairJob.RepairJobId }, repairJob);
        }

        // DELETE: api/RepairJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairJob(int id)
        {
            try
            {
                await _repairJobRepository.DeleteRepairJobAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
