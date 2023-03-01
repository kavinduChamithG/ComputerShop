using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerShop;
using ComputerShop.Models;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingsController : ControllerBase
    {
        private readonly ComputerShopDbContext _context;

        public TrackingsController(ComputerShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Trackings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tracking>>> Gettrackings()
        {
            return await _context.trackings.ToListAsync();
        }

        // GET: api/Trackings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tracking>> GetTracking(string id)
        {
            var tracking = await _context.trackings.FindAsync(id);

            if (tracking == null)
            {
                return NotFound();
            }

            return tracking;
        }

        // PUT: api/Trackings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTracking(string id, Tracking tracking)
        {
            if (id != tracking.TrackingID)
            {
                return BadRequest();
            }

            _context.Entry(tracking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingExists(id))
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

        // POST: api/Trackings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tracking>> PostTracking(Tracking tracking)
        {
            _context.trackings.Add(tracking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrackingExists(tracking.TrackingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTracking", new { id = tracking.TrackingID }, tracking);
        }

        // DELETE: api/Trackings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTracking(string id)
        {
            var tracking = await _context.trackings.FindAsync(id);
            if (tracking == null)
            {
                return NotFound();
            }

            _context.trackings.Remove(tracking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackingExists(string id)
        {
            return _context.trackings.Any(e => e.TrackingID == id);
        }
    }
}
