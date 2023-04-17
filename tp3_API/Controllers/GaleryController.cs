using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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

        // GET USER GALERY
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galery>>> GetGalery()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return user.Galery;
            }
        }

        // GET ALL PUBLIC GALERIES
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galery>>> GetPublicGaleries()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                List<Galery> galeries = new List<Galery>();

                foreach(Galery g in _context.Galery)
                {
                    if(g.IsPublic == true && !g.AllowedUser.Contains(user))
                    {
                        galeries.Add(g);
                    }
                }

                return galeries;
            }
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
            //Trouver un utilisateur via son token
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                galery.AllowedUser = new List<User>();
                galery.AllowedUser.Add(user);
                user.Galery.Add(galery);
                _context.Galery.Add(galery);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetGalery", new { id = galery.Id }, galery);
            }
        }

        // ADD A USER
        [HttpPut("{id}/{username}")]
        public async Task<IActionResult> AddUser(int id, string username)
        {
            var galery = await _context.Galery.FindAsync(id);
            if (galery == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if(!galery.AllowedUser.Contains(user))
            {
                return BadRequest();
            }

            foreach(User u in _context.Users)
            {
                if(u.UserName.ToLower() == username.ToLower())
                {
                    galery.AllowedUser.Add(u);
                    u.Galery.Add(galery);
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }


        //MAKE IT PUBLIC
        [HttpPut("{id}")]
        public async Task<IActionResult> MakePublic(int id, string username)
        {
            var galery = await _context.Galery.FindAsync(id);
            if (galery == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if (!galery.AllowedUser.Contains(user) || galery.IsPublic == true)
            {
                return BadRequest();
            }

            galery.IsPublic = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //MAKE IT PRIVATE
        [HttpPut("{id}")]
        public async Task<IActionResult> MakePrivate(int id)
        {
            var galery = await _context.Galery.FindAsync(id);
            if (galery == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if (!galery.AllowedUser.Contains(user) || galery.IsPublic == false)
            {
                return BadRequest();
            }

            galery.IsPublic = false;

            await _context.SaveChangesAsync();

            return NoContent();
        
        }


        // DELETE: api/Galery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalery(int id)
        {
            var gallery = await _context.Galery.FindAsync(id);

            if (gallery == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if(!gallery.AllowedUser.Contains(user))
            {
                return BadRequest();
            }

            List<User> AllowesUsers = gallery.AllowedUser;
            foreach(User allowedUser in AllowesUsers)
            {
                allowedUser.Galery.Remove(gallery);
            }

            gallery.AllowedUser.Clear();

            _context.Galery.Remove(gallery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GaleryExists(int id)
        {
            return (_context.Galery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
