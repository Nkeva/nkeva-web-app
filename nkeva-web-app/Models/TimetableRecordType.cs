using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class TimetableRecordType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Name { get; set; }
        public string? Description { get; set; } = null;

        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
    }
}
