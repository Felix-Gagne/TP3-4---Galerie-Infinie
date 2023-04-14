using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace tp3_API.Models
{
    public class User : IdentityUser
    {
        public virtual List<Galery> Galery { get; set; } = null!;
    }
}
