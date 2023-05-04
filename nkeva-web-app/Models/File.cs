namespace nkeva_web_app.Models
{
    public class File
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
