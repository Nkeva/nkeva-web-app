using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(1024)]
        public string? Description { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
    }
}
