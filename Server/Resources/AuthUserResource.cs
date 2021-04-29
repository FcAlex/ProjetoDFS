using System.ComponentModel.DataAnnotations;

namespace Server.Resources
{
    public class AuthUserResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }
    }
}
