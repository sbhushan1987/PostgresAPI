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
    public class PurchaseDetailsController : ControllerBase
    {
        private readonly eretailContext _context;

        public PurchaseDetailsController(eretailContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseDetails
        [HttpGet]
        public IEnumerable<Purchaseorderdetail> GetPurchaseorderdetail()
        {
            return _context.Purchaseorderdetail;
        }

        // GET: api/PurchaseDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseorderdetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchaseorderdetail = await _context.Purchaseorderdetail.FindAsync(id);

            if (purchaseorderdetail == null)
            {
                return NotFound();
            }

            return Ok(purchaseorderdetail);
        }

        // PUT: api/PurchaseDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseorderdetail([FromRoute] int id, [FromBody] Purchaseorderdetail purchaseorderdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseorderdetail.PurchaseOrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseorderdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseorderdetailExists(id))
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

        // POST: api/PurchaseDetails
        [HttpPost]
        public async Task<IActionResult> PostPurchaseorderdetail([FromBody] Purchaseorderdetail purchaseorderdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Purchaseorderdetail.Add(purchaseorderdetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseorderdetailExists(purchaseorderdetail.PurchaseOrderDetailId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseorderdetail", new { id = purchaseorderdetail.PurchaseOrderDetailId }, purchaseorderdetail);
        }

        // DELETE: api/PurchaseDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseorderdetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchaseorderdetail = await _context.Purchaseorderdetail.FindAsync(id);
            if (purchaseorderdetail == null)
            {
                return NotFound();
            }

            _context.Purchaseorderdetail.Remove(purchaseorderdetail);
            await _context.SaveChangesAsync();

            return Ok(purchaseorderdetail);
        }

        private bool PurchaseorderdetailExists(int id)
        {
            return _context.Purchaseorderdetail.Any(e => e.PurchaseOrderDetailId == id);
        }
    }
}