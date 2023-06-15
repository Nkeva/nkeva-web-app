using nkeva_web_app.Models.Anime;
using nkeva_web_app.Models.Interfaces;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class AnimeResponse : BaseResponse
    {
        public AnimeResponse(bool success, string? message, IAnime? data) : base(success, message, data != null ? new Anime(data) : null)
        {
        }

        public AnimeResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class Anime
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("year")]
            public int Year { get; set; }
            [JsonPropertyName("description")]
            public string Description { get; set; }
            [JsonPropertyName("titleImage")]
            public int TitleImage { get; set; }
            [JsonPropertyName("backgroundImage")]
            public int BackgroundImage { get; set; }
            [JsonPropertyName("episodes")]
            public int Episodes { get; set; } = 0;
            [JsonPropertyName("rating")]
            public double Rating { get; set; } = 0;
            [JsonPropertyName("animeGenre")]
            public AnimeGenre Genre { get; set; }
            [JsonPropertyName("animeFormat")]
            public AnimeFormat Format { get; set; }

            public Anime(IAnime anime)
            {
                Id = anime.Id;
                Name = anime.Name;
                Year = anime.Year;
                Description = anime.Description;
                TitleImage = anime.TitleImageId;
                BackgroundImage = anime.BackgroundImageId;
                Episodes = anime.Episodes;
                Rating = anime.Rating;
                Genre = anime.Genre;
                Format = anime.Format;
            }
        }
    }
}
