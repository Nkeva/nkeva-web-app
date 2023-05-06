using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class TaskType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Name { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
