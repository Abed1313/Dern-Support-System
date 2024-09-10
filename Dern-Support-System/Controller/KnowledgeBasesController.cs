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
    public class KnowledgeBasesController : ControllerBase
    {
        private readonly IKnowledgeBase _knowledgeBaseRepository;

        public KnowledgeBasesController(IKnowledgeBase knowledgeBaseRepository)
        {
            _knowledgeBaseRepository = knowledgeBaseRepository;
        }

        // GET: api/KnowledgeBases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeBase>>> GetKnowledgeBases()
        {
            var knowledgeBases = await _knowledgeBaseRepository.GetAllKnowledgeBasesAsync();
            if (knowledgeBases == null || !knowledgeBases.Any())
            {
                return NotFound();
            }
            return Ok(knowledgeBases);
        }

        // GET: api/KnowledgeBases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnowledgeBase>> GetKnowledgeBase(int id)
        {
            var knowledgeBase = await _knowledgeBaseRepository.GetKnowledgeBaseByIdAsync(id);
            if (knowledgeBase == null)
            {
                return NotFound();
            }
            return Ok(knowledgeBase);
        }

        // PUT: api/KnowledgeBases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnowledgeBase(int id, KnowledgeBaseDto knowledgeBaseDto)
        {
            if (id != knowledgeBaseDto.KnowledgeBaseId)
            {
                return BadRequest("Knowledge Base ID mismatch.");
            }

            try
            {
                var updatedKnowledgeBase = await _knowledgeBaseRepository.UpdateKnowledgeBaseAsync(knowledgeBaseDto, id);
                if (updatedKnowledgeBase == null)
                {
                    return NotFound($"Knowledge Base with ID {id} not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/KnowledgeBases
        [HttpPost]
        public async Task<ActionResult<KnowledgeBase>> PostKnowledgeBase(KnowledgeBaseDto knowledgeBaseDto)
        {
            if (knowledgeBaseDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdKnowledgeBase = await _knowledgeBaseRepository.AddKnowledgeBaseAsync(knowledgeBaseDto);
            if (createdKnowledgeBase == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating knowledge base.");
            }

            return CreatedAtAction(nameof(GetKnowledgeBase), new { id = createdKnowledgeBase.KnowledgeBaseId }, createdKnowledgeBase);
        }

        // DELETE: api/KnowledgeBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnowledgeBase(int id)
        {
            try
            {
                await _knowledgeBaseRepository.DeleteKnowledgeBaseAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
