using Microsoft.AspNetCore.Identity;

namespace tp3_API.Models
{
    public class User : IdentityUser
    {
        public virtual List<Galery> Galery { get; set; } = null!;
    }
}
