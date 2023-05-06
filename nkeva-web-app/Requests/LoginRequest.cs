using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class LoginRequest
    {
        [Required]
        [StringLength(32, MinimumLength = 1)]
        public string Login { get; set; }
        [Required]
        [StringLength(512, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
