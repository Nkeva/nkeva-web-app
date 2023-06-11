using nkeva_web_app.Models;
using nkeva_web_app.Models.Anime;
using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class AnimeCommentReactionResponse : BaseResponse
    {
        public AnimeCommentReactionResponse(bool success, string? message, IAnimeCommentReaction? data) : base(success, message, data != null ? new AnimeCommentReaction(data) : null)
        {
        }

        public AnimeCommentReactionResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class AnimeCommentReaction
        {
            [JsonPropertyName("userId")]
            public int UserId { get; set; }
            [JsonPropertyName("commentId")]
            public int CommentId { get; set; }
            [JsonPropertyName("liked")]
            public bool Liked { get; set; }

            public AnimeCommentReaction(IAnimeCommentReaction reaction)
            {
                Liked = reaction.Liked;
                UserId = reaction.UserId;
                CommentId = reaction.CommentId;
            }
        }
    }
}
