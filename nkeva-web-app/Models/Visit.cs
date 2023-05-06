using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Visit
    {
        public enum VisitType
        {
            Present = 0,
            Absent = 10,
            Late = 20
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public VisitType Type { get; set; }
        [Required]
        public int Points { get; set; }
        public int? Mark { get; set; } = null;
        [StringLength(512)]
        public string? Comment { get; set; } = null;
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int TimetableRecordId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual User Student { get; set; }
        public virtual TimetableRecord TimetableRecord { get; set; }
    }
}
