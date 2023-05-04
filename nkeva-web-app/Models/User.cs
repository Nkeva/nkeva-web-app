namespace nkeva_web_app.Models
{
    public class User
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public bool IsOnline { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }
        public virtual SchoolRole Role { get; set; }

        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public virtual ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public virtual ICollection<File> Files { get; set; } = new List<File>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
        public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
