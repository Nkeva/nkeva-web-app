using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [StringLength(255)]
        public string? Description { get; set; } = null;
        [Required]
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual User Owner { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
