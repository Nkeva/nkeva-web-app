using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PostCourseRequest
    {
        [StringLength(128)]
        [Required]
        public string Name { get; set; }
        [StringLength(1024)]
        public string? Description { get; set; } = null;
    }
}
