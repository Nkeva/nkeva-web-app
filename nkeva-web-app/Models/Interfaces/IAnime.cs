using nkeva_web_app.Models.Anime;

namespace nkeva_web_app.Models.Interfaces
{
    public interface IAnime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string TitleImage { get; set; }
        public string BackgroundImage { get; set; }
        public int GenreId { get; set; }
        public int FormatId { get; set; }
        public int Episodes { get; set; }
        public double Rating { get; set; }
        public AnimeGenre Genre { get; set; }
        public AnimeFormat Format { get; set; }
    }
}
