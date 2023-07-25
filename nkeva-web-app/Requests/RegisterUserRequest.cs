using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 2)]
        public string LastName { get; set; }
        [StringLength(128)]
        public string? MiddleName { get; set; }
        [Required]
        public string Role { get; set; }
        public bool IsBlocked { get; set; } = true;
    }
}
