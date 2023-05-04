namespace nkeva_web_app.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public string? Description { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual User Owner { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
