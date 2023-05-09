using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class SchoolRole : Interfaces.IRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(256)]
        public string? Description { get; set; } = null;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
