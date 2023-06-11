using nkeva_web_app.Models.Anime;

namespace nkeva_web_app.Models.Interfaces
{
    public interface IAnimeCommentReaction
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public bool Liked { get; set; }
        public User User { get; set; }
        public AnimeComment Comment { get; set; }
    }
}
