using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PostStudentsToGroupRequest
    {
        [Required]
        public int[] Ids { get; set; }
    }
}
