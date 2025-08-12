using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace CodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardsController : ControllerBase
    {
        private readonly EfCodeFirstContext _context;

        public StandardsController(EfCodeFirstContext context)
        {
            _context = context;
        }

        // GET: api/Standards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standard>>> GetStandards()
        {
            return await _context.Standards.Include(s => s.Students).ToListAsync();
        }


        // GET: api/Standards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Standard>> GetStandard(int id)
        {
            var standard = await _context.Standards.FindAsync(id);

            if (standard == null)
            {
                return NotFound();
            }

            return standard;
        }

        // PUT: api/Standards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStandard(int id, Standard standard)
        {
            if (id != standard.StandardId)
            {
                return BadRequest();
            }

            _context.Entry(standard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardExists(id))
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

        // POST: api/Standards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Standard>> PostStandard(Standard standard)
        {
            _context.Standards.Add(standard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStandard", new { id = standard.StandardId }, standard);
        }

        // DELETE: api/Standards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStandard(int id)
        {
            var standard = await _context.Standards.FindAsync(id);
            if (standard == null)
            {
                return NotFound();
            }

            _context.Standards.Remove(standard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StandardExists(int id)
        {
            return _context.Standards.Any(e => e.StandardId == id);
        }
    }
}
