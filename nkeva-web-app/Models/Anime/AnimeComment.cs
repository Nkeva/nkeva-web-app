using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class AnimeComment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AnimeId { get; set; }
        [Required]
        public int WriterId { get; set; }
        [Required]
        [MaxLength(2048), MinLength(1)]
        public string Comment { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;

        public Anime Anime { get; set; }
        public User Writer { get; set; }
    }
}
