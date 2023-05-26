using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class PutSchoolRequest
    {
        [Required]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? Address { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? City { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? Country { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string? ZipCode { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public bool? Active { get; set; }
    }
}
