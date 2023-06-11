using nkeva_web_app.Models;
using nkeva_web_app.Models.Anime;
using nkeva_web_app.Models.Interfaces;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class AnimeCommentResponse : BaseResponse
    {
        public AnimeCommentResponse(bool success, string? message, IAnimeComment? data) : base(success, message, data != null ? new AnimeComment(data) : null)
        {
        }

        public AnimeCommentResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class AnimeComment
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("comment")]
            public string Comment { get; set; }
            [JsonPropertyName("date")]
            public DateTime Date { get; set; } = DateTime.Now;
            [JsonPropertyName("writer")]
            public UserResponse.User Writer { get; set; }

            public AnimeComment(IAnimeComment comment)
            {
                Id = comment.Id;
                Comment = comment.Comment;
                Date = comment.Date;
                Writer = new UserResponse.User(comment.Writer);
            }
        }
    }
}
