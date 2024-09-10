﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;

namespace Dern_Support_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SparePartsController : ControllerBase
    {
        private readonly ISparePart _sparePartRepository;

        public SparePartsController(ISparePart sparePartRepository)
        {
            _sparePartRepository = sparePartRepository;
        }

        // GET: api/SpareParts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePart>>> GetSpareParts()
        {
            var spareParts = await _sparePartRepository.GetAllSparePartsAsync();
            if (spareParts == null)
            {
                return NotFound();
            }
            return Ok(spareParts);
        }

        // GET: api/SpareParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePart>> GetSparePart(int id)
        {
            var sparePart = await _sparePartRepository.GetSparePartByIdAsync(id);
            if (sparePart == null)
            {
                return NotFound();
            }
            return Ok(sparePart);
        }

        // PUT: api/SpareParts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSparePart(int id, SparePartDto sparePartDto)
        {
            if (id != sparePartDto.SparePartId)
            {
                return BadRequest();
            }

            try
            {
                var updatedSparePart = await _sparePartRepository.UpdateSparePartAsync(sparePartDto, id);
                if (updatedSparePart == null)
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

        // POST: api/SpareParts
        [HttpPost]
        public async Task<ActionResult<SparePart>> PostSparePart(SparePartDto sparePartDto)
        {
            var sparePart = await _sparePartRepository.AddSparePartAsync(sparePartDto);
            return CreatedAtAction(nameof(GetSparePart), new { id = sparePart.SparePartId }, sparePart);
        }

        // DELETE: api/SpareParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSparePart(int id)
        {
            try
            {
                await _sparePartRepository.DeleteSparePartAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
