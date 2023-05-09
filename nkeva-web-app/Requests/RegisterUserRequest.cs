using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        [StringLength(512, MinimumLength = 8)]
        public string Password { get; set; }
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
        public int RoleId { get; set; }
        public bool IsBlocked { get; set; } = true;
    }
}
