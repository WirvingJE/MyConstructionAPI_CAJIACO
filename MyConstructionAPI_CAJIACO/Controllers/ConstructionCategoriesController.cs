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
    public class ConstructionCategoriesController : ControllerBase
    {
        private readonly MyConstructionBDContext _context;

        public ConstructionCategoriesController(MyConstructionBDContext context)
        {
            _context = context;
        }

        // GET: api/ConstructionCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionCategory>>> GetConstructionCategories()
        {
          if (_context.ConstructionCategories == null)
          {
              return NotFound();
          }
            return await _context.ConstructionCategories.ToListAsync();
        }

        // GET: api/ConstructionCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionCategory>> GetConstructionCategory(int id)
        {
          if (_context.ConstructionCategories == null)
          {
              return NotFound();
          }
            var constructionCategory = await _context.ConstructionCategories.FindAsync(id);

            if (constructionCategory == null)
            {
                return NotFound();
            }

            return constructionCategory;
        }

        // PUT: api/ConstructionCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructionCategory(int id, ConstructionCategory constructionCategory)
        {
            if (id != constructionCategory.ConstructionCategory1)
            {
                return BadRequest();
            }

            _context.Entry(constructionCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionCategoryExists(id))
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

        // POST: api/ConstructionCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConstructionCategory>> PostConstructionCategory(ConstructionCategory constructionCategory)
        {
          if (_context.ConstructionCategories == null)
          {
              return Problem("Entity set 'MyConstructionBDContext.ConstructionCategories'  is null.");
          }
            _context.ConstructionCategories.Add(constructionCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructionCategory", new { id = constructionCategory.ConstructionCategory1 }, constructionCategory);
        }

        // DELETE: api/ConstructionCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructionCategory(int id)
        {
            if (_context.ConstructionCategories == null)
            {
                return NotFound();
            }
            var constructionCategory = await _context.ConstructionCategories.FindAsync(id);
            if (constructionCategory == null)
            {
                return NotFound();
            }

            _context.ConstructionCategories.Remove(constructionCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructionCategoryExists(int id)
        {
            return (_context.ConstructionCategories?.Any(e => e.ConstructionCategory1 == id)).GetValueOrDefault();
        }
    }
}
