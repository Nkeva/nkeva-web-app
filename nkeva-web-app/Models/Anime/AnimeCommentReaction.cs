using nkeva_web_app.Models.Enums;
using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class AnimeCommentReaction : IAnimeCommentReaction
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int CommentId { get; set; }
        [Required]
        public bool Liked { get; set; }
        public User User { get; set; }
        public AnimeComment Comment { get; set; }
    }
}
