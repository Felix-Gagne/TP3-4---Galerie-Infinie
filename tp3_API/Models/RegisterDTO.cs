using System.ComponentModel.DataAnnotations;

namespace tp3_API.Models
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set;} = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string PasswordConfirm { get; set; } = null!;
    }
}
