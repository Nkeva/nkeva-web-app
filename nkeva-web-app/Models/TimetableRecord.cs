namespace nkeva_web_app.Models
{
    public class TimetableRecord
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int? MeetingId { get; set; }
        public int TypeId { get; set; }
        public DateTime StartAt { get; set; }
        public bool Active { get; set; } = false;
        public string Room { get; set; }
        public int ExrtaPoints { get; set; } = 5;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }
        public virtual Course Course { get; set; }
        public virtual Group Group { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Meeting? Meeting { get; set; }
        public virtual TimetableRecordType Type { get; set; }

        public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
