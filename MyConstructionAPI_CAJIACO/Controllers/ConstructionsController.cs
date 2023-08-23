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
    //[ApiKey]
    public class ConstructionsController : ControllerBase
    {
        private readonly MyConstructionBDContext _context;

        public ConstructionsController(MyConstructionBDContext context)
        {
            _context = context;
        }

        // GET: api/Constructions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Construction>>> GetConstructions()
        {
          if (_context.Constructions == null)
          {
              return NotFound();
          }
            return await _context.Constructions.ToListAsync();
        }

        [HttpGet("GetConstructionListByUser")]
        public async Task<ActionResult<IEnumerable<Construction>>> GetProtocolListByUser(int id)
        {
            if (_context.Constructions == null)
            {
                return NotFound();
            }
            var constructionList = await _context.Constructions.Where(p => p.UserId.Equals(id)).ToListAsync();

            if (constructionList == null)
            {
                return NotFound();
            }

            return constructionList;
        }


        // GET: api/Constructions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Construction>> GetConstruction(int id)
        {
          if (_context.Constructions == null)
          {
              return NotFound();
          }
            var construction = await _context.Constructions.FindAsync(id);

            if (construction == null)
            {
                return NotFound();
            }

            return construction;
        }

        // PUT: api/Constructions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstruction(int id, Construction construction)
        {
            if (id != construction.ProtocolId)
            {
                return BadRequest();
            }

            _context.Entry(construction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionExists(id))
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

        // POST: api/Constructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Construction>> PostConstruction(Construction construction)
        {
          if (_context.Constructions == null)
          {
              return Problem("Entity set 'MyConstructionBDContext.Constructions'  is null.");
          }
            _context.Constructions.Add(construction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstruction", new { id = construction.ProtocolId }, construction);
        }

        // DELETE: api/Constructions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstruction(int id)
        {
            if (_context.Constructions == null)
            {
                return NotFound();
            }
            var construction = await _context.Constructions.FindAsync(id);
            if (construction == null)
            {
                return NotFound();
            }

            _context.Constructions.Remove(construction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructionExists(int id)
        {
            return (_context.Constructions?.Any(e => e.ProtocolId == id)).GetValueOrDefault();
        }
    }
}
