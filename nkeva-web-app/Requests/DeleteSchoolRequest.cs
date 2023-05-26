using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class DeleteSchoolRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
