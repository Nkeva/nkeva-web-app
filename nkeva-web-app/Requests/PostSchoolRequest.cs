using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PostSchoolRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string City { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Country { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ZipCode { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
        public bool Active { get; set; } = true;
    }
}
