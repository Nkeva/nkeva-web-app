using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? SchoolId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public long Size { get; set; }
        [Required]
        public int? OwnerId { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School? School { get; set; }
        public virtual User? Owner { get; set; } = null;

        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Anime.Anime> Animes { get; set; } = new List<Anime.Anime>();
    }
}
