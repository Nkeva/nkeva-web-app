using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(2048)]
        public string Text { get; set; }
        public int? FileId { get; set; } = null;
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public int WriterId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual File? File { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual User Writer { get; set; }
    }
}
