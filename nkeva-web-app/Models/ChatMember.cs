using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class ChatMember
    {
        [Key]
        public int ChatId { get; set; }
        [Key]
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Chat Chat { get; set; }
        public virtual User User { get; set; }
    }
}
