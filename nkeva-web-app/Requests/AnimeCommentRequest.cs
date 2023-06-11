using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class AnimeCommentRequest
    {
        [Required]
        [StringLength(2048, MinimumLength = 1)]
        public string Comment { get; set; }
        [Required]
        public int AnimeId { get; set; }
        [Required]
        public int WriterId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}