using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class GroupChatRequest
    {
        [Required]
        public int OwnerId { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? Description { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
