using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Dern_Support_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnician _technicianService;

        public TechniciansController(ITechnician technicianService)
        {
            _technicianService = technicianService;
        }

        // GET: api/Technicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technician>>> GetTechnicians()
        {
            var technicians = await _technicianService.GetAllTechniciansAsync();
            return Ok(technicians);
        }

        // GET: api/Technicians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Technician>> GetTechnician(int id)
        {
            var technician = await _technicianService.GetTechnicianByIdAsync(id);

            if (technician == null)
            {
                return NotFound($"Technician with ID {id} not found.");
            }

            return Ok(technician);
        }

        // POST: api/Technicians
        [HttpPost]
        public async Task<ActionResult<Technician>> AddTechnician(TechnicianDto technicianDto)
        {
            var newTechnician = await _technicianService.AddTechnicianAsync(technicianDto);
            return CreatedAtAction(nameof(GetTechnician), new { id = newTechnician.TechnicianId }, newTechnician);
        }

        // PUT: api/Technicians/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Technician>> UpdateTechnician(int id, TechnicianDto technicianDto)
        {
            try
            {
                var updatedTechnician = await _technicianService.UpdateTechnicianAsync(technicianDto, id);
                return Ok(updatedTechnician);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Technicians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            try
            {
                await _technicianService.DeleteTechnicianAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Technicians/{id}/allProjects
        [HttpGet("{id}/allTasks")]
        public async Task<ActionResult<List<TechnicianTask>>> GetTasksForTechnician(int id)
        {
            var tasks = await _technicianService.GetTasksForTechnician(id);

            if (tasks == null || !tasks.Any())
            {
                return NotFound($"No tasks found for Technician with ID {id}.");
            }

            return Ok(tasks);
        }


        // POST: api/Technicians/SubmitRequest
        [Authorize(Roles = "BusinessCustomer")]
        [Authorize(Roles = "IndividualCustomer")]
        [HttpPost("SubmitRequest")]
        public async Task<ActionResult<TechnicianTask>> SubmitARequest(TechnicianTask technicianTask)
        {
            var newTask = await _technicianService.SubmitARequest(technicianTask);
            return Ok(newTask);
        }

        // GET: api/Technicians/GetTechniciansRequests
        [Authorize(Roles = "Admin")]
        [HttpGet("GetTechniciansRequests")]
        public async Task<ActionResult<List<TechnicianTask>>> GetAllTasks()
        {
            var tasks = await _technicianService.GetAllSubmittedTasks();
            if (tasks == null || tasks.Count == 0)
            {
                return NotFound("No technician tasks found.");
            }
            return Ok(tasks);
        }

        // PUT: api/Technicians/UpdateRequestStatus/{taskId}
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRequestStatus/{taskId}")]
        public async Task<IActionResult> UpdateRequestStatus(int taskId, [FromBody] string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return BadRequest("Status is required.");
            }

            var updatedTask = await _technicianService.UpdateRequestStatus(taskId, status);
            if (updatedTask == null)
            {
                return NotFound($"No task found with ID {taskId}.");
            }

            return Ok(new { message = "Request status updated", task = updatedTask });
        }
    }
}
