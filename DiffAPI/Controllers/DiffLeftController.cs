using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DiffApi.Models;

namespace DiffApi.Controllers
{
    [Route("/v1/diff")]
    [ApiController]
    public class DiffLeftController : ControllerBase
    {
        private readonly DiffLeftContext diffLeftContext;

        public DiffLeftController(DiffLeftContext context)
        {
            diffLeftContext = context;
        }

        // GET: v1/diff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiffLeft>>> GetDiffLefts()
        {
            return await diffLeftContext.DiffLefts.ToListAsync();
        }

        // GET: v1/diff/1
        [HttpGet("{id}")]
        public async Task<ActionResult<DiffLeft>> GetDiffLeft(long id)
        {
            var diffLeft = await diffLeftContext.DiffLefts.FindAsync(id);

            if (diffLeft == null)
            {
                return NotFound();
            }

            return diffLeft;
        }

        // PUT: v1/diff/1
        [HttpPut("{id")]
        public async Task<IActionResult> PutDiffLeft(long id, DiffLeft diffLeft)
        {
            if (id != diffLeft.id)
            {
                return BadRequest();
            }

            diffLeftContext.Entry(diffLeft).State = EntityState.Modified;

            try
            {
                await diffLeftContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiffLeftExists(id))
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

        // POST: v1/diff
        [HttpPost]
        public async Task<ActionResult<DiffLeft>> PostDiffLeft(DiffLeft diffLeft)
        {
            diffLeftContext.DiffLefts.Add(diffLeft);
            await diffLeftContext.SaveChangesAsync();

            //return CreatedAtAction("GetDiffItem", new { id = diffItem.id }, diffItem);
            //CreatedAtAction method returns an HTTP 201 status code if successful (the standard response for an HTTP POST method that creates a new response on the server
            return CreatedAtAction(nameof(GetDiffLeft), new { id = diffLeft.id }, diffLeft);
        }

        // DELETE: v1/diff/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiffLeft>> DeleteDiffLeft(long id)
        {
            var diffLeft = await diffLeftContext.DiffLefts.FindAsync(id);
            if (diffLeft == null)
            {
                return NotFound();
            }

            diffLeftContext.DiffLefts.Remove(diffLeft);
            await diffLeftContext.SaveChangesAsync();

            return diffLeft;
        }

        private bool DiffLeftExists(long id)
        {
            return diffLeftContext.DiffLefts.Any(e => e.id == id);
        }
    }
}
