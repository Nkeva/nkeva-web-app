using nkeva_web_app.Models.Enums;

namespace nkeva_web_app.Models.Interfaces
{
    public interface IUserAnime
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public bool IsFavorite { get; set; }
        public AnimeWatchingState State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rewatches { get; set; }
        public int EpisodesWatched { get; set; }
        public string Notes { get; set; }
        public Anime.Anime Anime { get; set; }
        public User User { get; set; }
    }
}
