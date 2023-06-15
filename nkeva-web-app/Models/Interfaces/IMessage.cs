using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Interfaces
{
    public interface IMessage
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public int? FileId { get; set; }
        public bool IsChanged { get; set; }
        public bool IsRead { get; set; }
        public int? ReplyToId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Chat Chat { get; set; }
        public User Sender { get; set; }
        public File? File { get; set; }
        public Message? ReplyTo { get; set; }
    }
}
