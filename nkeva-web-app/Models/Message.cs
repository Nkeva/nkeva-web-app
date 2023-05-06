using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ChatId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        [StringLength(2048)]
        public string Text { get; set; }
        public int? FileId { get; set; } = null;
        public bool IsChanged { get; set; } = false;
        public bool IsRead { get; set; } = false;
        public int? ReplyToId { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual Chat Chat { get; set; }
        public virtual User Sender { get; set; }
        public virtual File? File { get; set; }
        public virtual Message? ReplyTo { get; set; }

        public virtual ICollection<Message> Replies { get; set; } = new List<Message>();
    }
}
