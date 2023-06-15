using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PrivateChatRequest
    {
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int FirstUserId { get; set; }
        [Required]
        public int SecondUserId { get; set; }
        [StringLength(255, MinimumLength = 0)]
        public string? Description { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
