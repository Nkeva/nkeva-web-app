using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual User Creator { get; set; }

        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
    }
}
