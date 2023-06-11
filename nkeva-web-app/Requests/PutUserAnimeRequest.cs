using nkeva_web_app.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PutUserAnimeRequest
    {
        [Required]
        public bool IsFavorite { get; set; }
        [Required]
        public AnimeWatchingState State { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Rewatches { get; set; } = 0;
        [Required]
        public int EpisodesWatched { get; set; } = 0;
        [Required]
        [StringLength(2048, MinimumLength = 0)]
        public string Notes { get; set; } = "";
    }
}
