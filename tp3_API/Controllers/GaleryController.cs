using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using tp3_API.Data;
using tp3_API.Models;

namespace tp3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GaleryController : ControllerBase
    {
        private readonly UserContext _context;

        public GaleryController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Galery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galery>>> GetGalery()
        {
          if (_context.Galery == null)
          {
              return NotFound();
          }
            return await _context.Galery.ToListAsync();
        }

        // GET: api/Galery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galery>> GetGalery(int id)
        {
          if (_context.Galery == null)
          {
              return NotFound();
          }
            var galery = await _context.Galery.FindAsync(id);

            if (galery == null)
            {
                return NotFound();
            }

            return galery;
        }

        // PUT: api/Galery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalery(int id, Galery galery)
        {
            if (id != galery.Id)
            {
                return BadRequest();
            }

            _context.Entry(galery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GaleryExists(id))
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

        // POST: api/Galery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galery>> PostGalery(Galery galery)
        {

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await _context.Users.FindAsync(userId);

                // Ajouter les references
                galery.AllowedUser = new List<User>();
                galery.AllowedUser.Add(user);
                user.Galery.Add(galery);

                // Populer la base de donner
                _context.Galery.Add(galery);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetGalery", new { id = galery.Id }, galery);

        }

        // DELETE: api/Galery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalery(int id)
        {
            if (_context.Galery == null)
            {
                return NotFound();
            }
            var galery = await _context.Galery.FindAsync(id);
            if (galery == null)
            {
                return NotFound();
            }

            _context.Galery.Remove(galery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GaleryExists(int id)
        {
            return (_context.Galery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
