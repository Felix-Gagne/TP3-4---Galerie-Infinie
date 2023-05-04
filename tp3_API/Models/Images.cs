using System.Security.Policy;

namespace tp3_API.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? FileName { get; set; }
        public string? MimeType { get; set; }
        public virtual Galery? Galery { get; set; }
    }
}
