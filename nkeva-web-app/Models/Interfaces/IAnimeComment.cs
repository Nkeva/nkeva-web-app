namespace nkeva_web_app.Models.Interfaces
{
    public interface IAnimeComment
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public int WriterId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Anime.Anime Anime { get; set; }
        public User Writer { get; set; }
    }
}
