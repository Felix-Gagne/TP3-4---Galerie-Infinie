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
    public class GaleryController : ControllerBase
    {
        private readonly UserContext _context;

        public GaleryController(UserContext context)
        {
            _context = context;
        }

        // GET USER GALERY
        [HttpGet]
        [Authorize]
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

            try
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

                    foreach (Galery g in _context.Galery)
                    {
                        if (g.IsPublic == true && !g.AllowedUser.Contains(user))
                        {
                            galeries.Add(g);
                        }
                    }

                    return galeries;
                }
            }
            catch (Exception ex)
            {
                List<Galery> galeries = new List<Galery>();

                foreach (Galery g in _context.Galery)
                {
                    if (g.IsPublic == true)
                    {
                        galeries.Add(g);
                    }
                }

                return galeries;
            }
        }

        // POST: api/Galery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Galery>> PostGalery()
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
                string? galeryName = Request.Form["galeryName"];
                string? boolEnString = Request.Form["isPublic"];
                if(galeryName == null || boolEnString == null)
                {
                    return BadRequest("Il manque des données");
                }

                bool isPublic = bool.Parse(boolEnString);

                Galery galery = new Galery()
                {
                    Id = 0,
                    Name = galeryName,
                    IsPublic = isPublic
                };
                galery.AllowedUser = new List<User>();
                galery.AllowedUser.Add(user);

                try
                {
                    IFormCollection formCollection = await Request.ReadFormAsync();
                    IFormFile? file = formCollection.Files.GetFile("monImage");
                    if(file != null)
                    {
                        Image image = Image.Load(file.OpenReadStream());

                        galery.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        galery.MimeType = file.ContentType;

                        image.Mutate(i =>
                        i.Resize(new ResizeOptions()
                        {
                            Mode = ResizeMode.Min,
                            Size = new Size() { Width = 252 }
                        })
                        );
                        image.Save(Directory.GetCurrentDirectory() + "/images/cover/" + galery.FileName);
                    }
                    else
                    {
                        galery.FileName = "11111111-1111-1111-1111-111111111111.png";
                        galery.MimeType = "image/png";
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                user.Galery.Add(galery);
                _context.Galery.Add(galery);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetGalery", new { id = galery.Id }, galery);
            }
        }

        // ADD A USER
        [HttpPut("{id}/{username}")]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> MakePublic(int id)
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
        [Authorize]
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
        [Authorize]
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

            foreach(Images i in gallery.Images)
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/miniature/" + i.FileName);
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/original/" + i.FileName);
                _context.Images.Remove(i);
            }

            System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/cover/" + gallery.FileName);

            _context.Galery.Remove(gallery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/{FileName}")]
        public async Task<ActionResult> getGaleryCoverPicture(int id, string FileName)
        {
            if(_context.Galery == null)
            {
                return NotFound();
            }
            Galery? galery = await _context.Galery.FindAsync(id);
            if(galery == null || galery.FileName == null || galery.MimeType == null)
            {
                return NotFound(new { Message = "Cette galerie n'a pas de photo." });
            }
            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/cover/" + galery.FileName);
            return File(bytes, galery.MimeType);
        }

        //Change cover picture
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ChangeCoverPicture(int id)
        {
            var galery = await _context.Galery.FindAsync(id);
            if (galery == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = _context.Users.Single(u => u.Id == userId);

            if (!galery.AllowedUser.Contains(user))
            {
                return BadRequest();
            }


            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if (file != null)
                {
                    Image image = Image.Load(file.OpenReadStream());

                    galery.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    galery.MimeType = file.ContentType;

                    image.Mutate(i =>
                    i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 252 }
                    })
                    );
                    image.Save(Directory.GetCurrentDirectory() + "/images/cover/" + galery.FileName);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }

            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool GaleryExists(int id)
        {
            return (_context.Galery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
