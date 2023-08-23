using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyConstructionAPI_CAJIACO.Models;

namespace MyConstructionAPI_CAJIACO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionStepsController : ControllerBase
    {
        private readonly MyConstructionBDContext _context;

        public ConstructionStepsController(MyConstructionBDContext context)
        {
            _context = context;
        }

        // GET: api/ConstructionSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionStep>>> GetConstructionSteps()
        {
          if (_context.ConstructionSteps == null)
          {
              return NotFound();
          }
            return await _context.ConstructionSteps.ToListAsync();
        }

        // GET: api/ConstructionSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionStep>> GetConstructionStep(int id)
        {
          if (_context.ConstructionSteps == null)
          {
              return NotFound();
          }
            var constructionStep = await _context.ConstructionSteps.FindAsync(id);

            if (constructionStep == null)
            {
                return NotFound();
            }

            return constructionStep;
        }

        // PUT: api/ConstructionSteps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructionStep(int id, ConstructionStep constructionStep)
        {
            if (id != constructionStep.ConstructionStepsId)
            {
                return BadRequest();
            }

            _context.Entry(constructionStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionStepExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ConstructionSteps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConstructionStep>> PostConstructionStep(ConstructionStep constructionStep)
        {
          if (_context.ConstructionSteps == null)
          {
              return Problem("Entity set 'MyConstructionBDContext.ConstructionSteps'  is null.");
          }
            _context.ConstructionSteps.Add(constructionStep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructionStep", new { id = constructionStep.ConstructionStepsId }, constructionStep);
        }

        // DELETE: api/ConstructionSteps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructionStep(int id)
        {
            if (_context.ConstructionSteps == null)
            {
                return NotFound();
            }
            var constructionStep = await _context.ConstructionSteps.FindAsync(id);
            if (constructionStep == null)
            {
                return NotFound();
            }

            _context.ConstructionSteps.Remove(constructionStep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructionStepExists(int id)
        {
            return (_context.ConstructionSteps?.Any(e => e.ConstructionStepsId == id)).GetValueOrDefault();
        }
    }
}
