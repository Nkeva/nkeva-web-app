namespace nkeva_web_app.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public bool IsSubGroup { get; set; } = false;
        public bool Active { get; set; } = false;
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }

        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
