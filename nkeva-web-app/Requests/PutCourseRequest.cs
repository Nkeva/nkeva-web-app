using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PutCourseRequest
    {
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(1024)]
        public string? Description { get; set; } = null;
    }
}
