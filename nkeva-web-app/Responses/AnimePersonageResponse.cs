using nkeva_web_app.Models.Anime;
using nkeva_web_app.Models.Enums;
using nkeva_web_app.Models.Interfaces;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class AnimePersonageResponse : BaseResponse
    {
        public AnimePersonageResponse(bool success, string? message, IAnimePersonage? data) : base(success, message, data != null ? new AnimePersonage(data) : null)
        {
        }

        public AnimePersonageResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class AnimePersonage
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("image")]
            public string Image { get; set; }
            [JsonPropertyName("role")]
            public AnimePersonageRole Role { get; set; }
            [JsonPropertyName("actor")]
            public AnimeActor Actor { get; set; }

            public AnimePersonage(IAnimePersonage personage)
            {
                Id = personage.Id;
                Name = personage.Name;
                Image = personage.Image;
                Role = personage.Role;
                Actor = personage.Actor;
            }
        }
    }
}
