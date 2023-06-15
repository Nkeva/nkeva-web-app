using nkeva_web_app.Models.Anime;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Interfaces
{
    public interface IAnime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        [Required]
        public int TitleImageId { get; set; }
        [Required]
        public int BackgroundImageId { get; set; }
        public int GenreId { get; set; }
        public int FormatId { get; set; }
        public int Episodes { get; set; }
        public double Rating { get; set; }
        public AnimeGenre Genre { get; set; }
        public AnimeFormat Format { get; set; }
        public File TitleImage { get; set; }
        public File BackgroundImage { get; set; }
    }
}
