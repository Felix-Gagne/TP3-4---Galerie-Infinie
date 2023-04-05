using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tp3_API.Models;

namespace tp3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserManager<User> UserManager;

        public UsersController(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if(register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les deux mots de passe spécifiés sont différents" });
            }

            User user = new User()
            {
                UserName = register.Username,
                Email = register.Email
            };
            
            IdentityResult identityResult = await UserManager.CreateAsync(user, register.Password);
            
            if(!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La création de l'utilisateur a échoué." });
            }

            return Ok();
        }

    }
}
