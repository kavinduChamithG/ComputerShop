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
    public class Cart_orderController : ControllerBase
    {
        private readonly ComputerShopDbContext _context;

        public Cart_orderController(ComputerShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Cart_order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart_order>>> Getcart_Orders()
        {
            return await _context.cart_Orders.ToListAsync();
        }

        // GET: api/Cart_order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart_order>> GetCart_order(string id)
        {
            var cart_order = await _context.cart_Orders.FindAsync(id);

            if (cart_order == null)
            {
                return NotFound();
            }

            return cart_order;
        }

        // PUT: api/Cart_order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart_order(string id, Cart_order cart_order)
        {
            if (id != cart_order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(cart_order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cart_orderExists(id))
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

        // POST: api/Cart_order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart_order>> PostCart_order(Cart_order cart_order)
        {
            _context.cart_Orders.Add(cart_order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Cart_orderExists(cart_order.OrderID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCart_order", new { id = cart_order.OrderID }, cart_order);
        }

        // DELETE: api/Cart_order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart_order(string id)
        {
            var cart_order = await _context.cart_Orders.FindAsync(id);
            if (cart_order == null)
            {
                return NotFound();
            }

            _context.cart_Orders.Remove(cart_order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cart_orderExists(string id)
        {
            return _context.cart_Orders.Any(e => e.OrderID == id);
        }
    }
}
