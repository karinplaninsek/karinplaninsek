using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiffAPI.Models;

namespace DiffAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiffItemsController : ControllerBase
    {
        private readonly DiffContext _context;

        public DiffItemsController(DiffContext context)
        {
            _context = context;
        }

        // GET: v1/DiffItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiffItem>>> GetDiffItems()
        {
            return await _context.DiffItems.ToListAsync();
        }

        // GET: v1/DiffItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiffItem>> GetDiffItem(long id)
        {
            var diffItem = await _context.DiffItems.FindAsync(id);

            if (diffItem == null)
            {
                return NotFound();
            }

            return diffItem;
        }

        // PUT: v1/DiffItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiffItem(long id, DiffItem diffItem)
        {
            if (id != diffItem.id)
            {
                return BadRequest();
            }

            _context.Entry(diffItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiffItemExists(id))
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

        // POST: v1/DiffItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DiffItem>> PostDiffItem(DiffItem diffItem)
        {
            _context.DiffItems.Add(diffItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetDiffItem", new { id = diffItem.id }, diffItem);
            //CreatedAtAction method returns an HTTP 201 status code if successful (the standard response for an HTTP POST method that creates a new response on the server
            return CreatedAtAction(nameof(GetDiffItem), new { id = diffItem.id }, diffItem);
        }

        // DELETE: v1/DiffItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiffItem>> DeleteDiffItem(long id)
        {
            var diffItem = await _context.DiffItems.FindAsync(id);
            if (diffItem == null)
            {
                return NotFound();
            }

            _context.DiffItems.Remove(diffItem);
            await _context.SaveChangesAsync();

            return diffItem;
        }

        private bool DiffItemExists(long id)
        {
            return _context.DiffItems.Any(e => e.id == id);
        }
    }
}
