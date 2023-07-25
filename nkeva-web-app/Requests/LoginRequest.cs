using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(512, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
