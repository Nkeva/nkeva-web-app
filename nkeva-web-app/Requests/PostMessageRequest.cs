using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PostMessageRequest
    {
        [Required]
        [StringLength(2048, MinimumLength = 1)]
        public string Text { get; set; }
        public int? ReplyToId { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
