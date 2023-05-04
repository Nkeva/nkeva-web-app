namespace nkeva_web_app.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<User>? Users { get; set; } = new List<User>();
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
        public virtual ICollection<Group>? Groups { get; set; } = new List<Group>();
        public virtual ICollection<Tasks>? Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<File>? Files { get; set; } = new List<File>();
        public virtual ICollection<Answer>? Answers { get; set; } = new List<Answer>();
        public virtual ICollection<Chat>? Chats { get; set; } = new List<Chat>();
        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
    }
}
