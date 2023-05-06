using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [StringLength(512, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string? Surname { get; set; } = null;
        [Required]
        public int StaffRoleId { get; set; }
        public bool IsActivated { get; set; } = false;
        public bool IsOnline { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual StaffRole StaffRole { get; set; }
    }
}
