namespace nkeva_web_app.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
    }
}
