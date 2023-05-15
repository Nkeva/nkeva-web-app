using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class UserAnime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AnimeId { get; set; }
        [Required]
        public int UserId { get; set; }
        public int Rating { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsWatching { get; set; }
        public bool Completed { get; set; }
        public bool Dropped { get; set; }
        public bool Planning { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int Rewatches { get; set; } = 0;
        public int EpisodesWatched { get; set; } = 0;
        public string Notes { get; set; } = "";

        public Anime Anime { get; set; }
        public User User { get; set; }
    }
}
