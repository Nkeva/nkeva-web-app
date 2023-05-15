using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Staff : IUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 1)]
        public string Login { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(2048, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string? MiddleName { get; set; } = null;
        [Required]
        public int RoleId { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsOnline { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual StaffRole Role { get; set; }

        public IRole UserRole => Role;
    }
}
