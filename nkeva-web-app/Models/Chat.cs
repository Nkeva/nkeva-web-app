using System.ComponentModel.DataAnnotations;
using nkeva_web_app.Models.Interfaces;

namespace nkeva_web_app.Models
{
    public class Chat : IChat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int? OwnerId { get; set; }
        [StringLength(255)]
        public string? Name { get; set; } = null;
        [StringLength(255)]
        public string? Description { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual User? Owner { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
