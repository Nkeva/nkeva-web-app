using nkeva_web_app.Models;
using nkeva_web_app.Models.Anime;
using nkeva_web_app.Models.Enums;
using nkeva_web_app.Models.Interfaces;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class UserAnimeResponse : BaseResponse
    {
        public UserAnimeResponse(bool success, string? message, IUserAnime? data) : base(success, message, data != null ? new UserAnime(data) : null)
        {
        }

        public UserAnimeResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class UserAnime
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("rating")]
            public int Rating { get; set; }
            [JsonPropertyName("isFavorite")]
            public bool IsFavorite { get; set; }
            [JsonPropertyName("state")]
            public AnimeWatchingState State { get; set; }
            [JsonPropertyName("startDate")]
            public DateTime StartDate { get; set; }
            [JsonPropertyName("endDate")]
            public DateTime EndDate { get; set; }
            [JsonPropertyName("rewatches")]
            public int Rewatches { get; set; }
            [JsonPropertyName("episodesWatched")]
            public int EpisodesWatched { get; set; }
            [JsonPropertyName("notes")]
            public string Notes { get; set; } = "";
            [JsonPropertyName("anime")]
            public Anime Anime { get; set; }
            [JsonPropertyName("user")]
            public User User { get; set; }

            public UserAnime(IUserAnime data)
            {
                Id = data.Id;
                Rating = data.Rating;
                IsFavorite = data.IsFavorite;
                State = data.State;
                StartDate = data.StartDate;
                EndDate = data.EndDate;
                Rewatches = data.Rewatches;
                EpisodesWatched = data.EpisodesWatched;
                Notes = data.Notes;
                Anime = data.Anime;
                User = data.User;
            }
        }
    }
}
