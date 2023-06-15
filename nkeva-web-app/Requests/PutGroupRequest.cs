using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PutGroupRequest
    {
        [StringLength(255, MinimumLength = 1)]
        public string? Name { get; set; }
        public int? TeacherId { get; set; }
        public bool IsSubGroup { get; set; } = false;
        public bool Active { get; set; } = false;
    }
}
