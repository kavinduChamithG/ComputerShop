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
    public class Cart_ItemController : ControllerBase
    {
        private readonly ComputerShopDbContext _context;

        public Cart_ItemController(ComputerShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Cart_Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart_Item>>> Getcart_items()
        {
            return await _context.cart_items.ToListAsync();
        }

        // GET: api/Cart_Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart_Item>> GetCart_Item(int id)
        {
            var cart_Item = await _context.cart_items.FindAsync(id);

            if (cart_Item == null)
            {
                return NotFound();
            }

            return cart_Item;
        }

        // PUT: api/Cart_Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart_Item(int id, Cart_Item cart_Item)
        {
            if (id != cart_Item.CartItemID)
            {
                return BadRequest();
            }

            _context.Entry(cart_Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cart_ItemExists(id))
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

        // POST: api/Cart_Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart_Item>> PostCart_Item(Cart_Item cart_Item)
        {
            _context.cart_items.Add(cart_Item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart_Item", new { id = cart_Item.CartItemID }, cart_Item);
        }

        // DELETE: api/Cart_Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart_Item(int id)
        {
            var cart_Item = await _context.cart_items.FindAsync(id);
            if (cart_Item == null)
            {
                return NotFound();
            }

            _context.cart_items.Remove(cart_Item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cart_ItemExists(int id)
        {
            return _context.cart_items.Any(e => e.CartItemID == id);
        }
    }
}
