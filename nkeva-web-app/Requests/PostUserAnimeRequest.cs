using nkeva_web_app.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PostUserAnimeRequest
    {
        [Required]
        public int AnimeId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool IsFavorite { get; set; }
        [Required]
        public AnimeWatchingState State { get; set; }
        public int Rating { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int Rewatches { get; set; } = 0;
        public int EpisodesWatched { get; set; } = 0;
        [StringLength(2048, MinimumLength = 0)]
        public string Notes { get; set; } = "";
    }
}
