using Microsoft.Build.Framework;
using System.Text.Json.Serialization;

namespace tp3_API.Models
{
    public class Galery
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public string? FileName { get; set; }

        public string? MimeType { get; set; }

        [JsonIgnore]
        public virtual List<User>? AllowedUser { get; set; }

        public virtual List<Images>? Images { get; set; }
    }
}
