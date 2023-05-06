using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int TaskTypeId { get; set; }
        [Required]
        public int TimetableRecordId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Text { get; set; }
        public int? FileId { get; set; } = null;
        public DateTime? Deadline { get; set; } = null;
        public bool Active { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }
        public virtual Course Course { get; set; }
        public virtual Group Group { get; set; }
        public virtual File File { get; set; }
        public virtual TimetableRecord TimetableRecord { get; set; }
        public virtual TaskType TaskType { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
