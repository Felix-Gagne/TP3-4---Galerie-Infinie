using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace tp3_API.Models
{
    public class Galery
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public string DefaultImage { get; set; }

        [JsonIgnore]
        public virtual List<User> AllowedUser { get; set; }
    }
}
