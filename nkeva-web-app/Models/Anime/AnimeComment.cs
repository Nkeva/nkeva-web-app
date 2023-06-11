using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class AnimeComment : IAnimeComment
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
        public Anime Anime { get; set; }
        public User Writer { get; set; }

        public virtual ICollection<AnimeCommentReaction> Reactions { get; set; } = new List<AnimeCommentReaction>();
    }
}
