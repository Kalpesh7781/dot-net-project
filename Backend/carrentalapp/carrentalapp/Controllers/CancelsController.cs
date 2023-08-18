using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carrentalapp.Data;
using carrentalapp.Model;

namespace carrentalapp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CancelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CancelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cancels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancel>>> GetCancels()
        {
          if (_context.Cancels == null)
          {
              return NotFound();
          }
            return await _context.Cancels.Include(a=>a.car).Include(b=>b.user).ToListAsync();
        }

        // GET: api/Cancels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancel>> GetCancel(long id)
        {
          if (_context.Cancels == null)
          {
              return NotFound();
          }
            var cancel = await _context.Cancels.FindAsync(id);

            if (cancel == null)
            {
                return NotFound();
            }

            return cancel;
        }

        // PUT: api/Cancels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancel(long id, Cancel cancel)
        {
            if (id != cancel.booking_id)
            {
                return BadRequest();
            }

            _context.Entry(cancel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancelExists(id))
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

        // POST: api/Cancels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cancel>> PostCancel(Cancel cancel)
        {
          if (_context.Cancels == null)
          {
              return Problem("Entity set 'AppDbContext.Cancels'  is null.");
          }
            _context.Cancels.Add(cancel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CancelExists(cancel.booking_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCancel", new { id = cancel.booking_id }, cancel);
        }

        // DELETE: api/Cancels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancel(long id)
        {
            if (_context.Cancels == null)
            {
                return NotFound();
            }
            var cancel = await _context.Cancels.FindAsync(id);
            if (cancel == null)
            {
                return NotFound();
            }

            _context.Cancels.Remove(cancel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancelExists(long id)
        {
            return (_context.Cancels?.Any(e => e.booking_id == id)).GetValueOrDefault();
        }
    }
}
