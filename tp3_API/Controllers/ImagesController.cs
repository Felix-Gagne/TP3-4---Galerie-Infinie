using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp3_API.Data;
using tp3_API.Models;

namespace tp3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly UserContext _context;

        public ImagesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet("{id}")]
        public async Task<ActionResult> ShowImages(int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            Images? image = await _context.Images.FindAsync(id);
            if (image == null || image.FileName == null || image.MimeType == null)
            {
                return NotFound(new { Message = "Cette image n'existe pas." });
            }
            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/original/" + image.FileName);
            return File(bytes, image.MimeType);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Images>>> GetImages(int id)
        {
            var galery = await _context.Galery.FindAsync(id);
            if(galery == null)
            {
                return BadRequest();
            }
            else
            {
                return galery.Images;
            }
        }


        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{galeryId}")]
        [Authorize]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Images>> addImageToGalery(int galeryId)
        {
            var galery = await _context.Galery.FindAsync(galeryId);
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
                    Images images = new Images();

                    images.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    images.MimeType = file.ContentType;

                    image.Save(Directory.GetCurrentDirectory() + "/images/original/" + images.FileName);

                    galery.Images = new List<Images>();
                    galery.Images.Add(images);

                    images.Galery = galery;

                    _context.Images.Add(images);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
            }

            catch (Exception ex)
            {
                throw;
            }

            return NoContent();
        }

    // DELETE: api/Images/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImages(int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            var images = await _context.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }

            _context.Images.Remove(images);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagesExists(int id)
        {
            return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
