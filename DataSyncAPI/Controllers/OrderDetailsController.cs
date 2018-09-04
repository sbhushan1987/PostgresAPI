using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataSyncAPI;

namespace DataSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly eretailContext _context;

        public OrderDetailsController(eretailContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IEnumerable<Orderdetail> GetOrderdetail()
        {
            return _context.Orderdetail;
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderdetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderdetail = await _context.Orderdetail.FindAsync(id);

            if (orderdetail == null)
            {
                return NotFound();
            }

            return Ok(orderdetail);
        }

        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderdetail([FromRoute] int id, [FromBody] Orderdetail orderdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderdetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderdetailExists(id))
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

        // POST: api/OrderDetails
        [HttpPost]
        public async Task<IActionResult> PostOrderdetail([FromBody] Orderdetail orderdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orderdetail.Add(orderdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderdetail", new { id = orderdetail.Id }, orderdetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderdetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderdetail = await _context.Orderdetail.FindAsync(id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            _context.Orderdetail.Remove(orderdetail);
            await _context.SaveChangesAsync();

            return Ok(orderdetail);
        }

        private bool OrderdetailExists(int id)
        {
            return _context.Orderdetail.Any(e => e.Id == id);
        }
    }
}