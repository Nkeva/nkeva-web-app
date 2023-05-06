using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string City { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Country { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ZipCode { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<User>? Users { get; set; } = new List<User>();
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
        public virtual ICollection<Group>? Groups { get; set; } = new List<Group>();
        public virtual ICollection<Tasks>? Tasks { get; set; } = new List<Tasks>();
        public virtual ICollection<File>? Files { get; set; } = new List<File>();
        public virtual ICollection<Answer>? Answers { get; set; } = new List<Answer>();
        public virtual ICollection<Chat>? Chats { get; set; } = new List<Chat>();
        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
    }
}
