using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class ChatMember
    {
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Chat Chat { get; set; }
        public virtual User User { get; set; }
    }
}
