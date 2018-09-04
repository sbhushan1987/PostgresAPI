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
    public class InventoryController : ControllerBase
    {
        private readonly eretailContext _context;

        public InventoryController(eretailContext context)
        {
            _context = context;
        }

        // GET: api/Inventory
        [HttpGet]
        public IEnumerable<Inventorydetail> GetInventorydetail()
        {
            return _context.Inventorydetail;
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventorydetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventorydetail = await _context.Inventorydetail.FindAsync(id);

            if (inventorydetail == null)
            {
                return NotFound();
            }

            return Ok(inventorydetail);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventorydetail([FromRoute] int id, [FromBody] Inventorydetail inventorydetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventorydetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventorydetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventorydetailExists(id))
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

        // POST: api/Inventory
        [HttpPost]
        public async Task<IActionResult> PostInventorydetail([FromBody] Inventorydetail inventorydetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inventorydetail.Add(inventorydetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventorydetail", new { id = inventorydetail.Id }, inventorydetail);
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventorydetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventorydetail = await _context.Inventorydetail.FindAsync(id);
            if (inventorydetail == null)
            {
                return NotFound();
            }

            _context.Inventorydetail.Remove(inventorydetail);
            await _context.SaveChangesAsync();

            return Ok(inventorydetail);
        }

        private bool InventorydetailExists(int id)
        {
            return _context.Inventorydetail.Any(e => e.Id == id);
        }
    }
}