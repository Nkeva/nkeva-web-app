using nkeva_web_app.Models.Anime;
using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models
{
    public class User : IUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string LastName { get; set; }
        [StringLength(128)]
        public string? MiddleName { get; set; } = null;
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(32)]
        public string Login { get; set; }
        [Required]
        [StringLength(2048, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsOnline { get; set; } = false;
        public bool IsBlocked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }
        public virtual SchoolRole Role { get; set; }
        public IRole UserRole => Role;

        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public virtual ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public virtual ICollection<File> Files { get; set; } = new List<File>();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
        public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
        public virtual ICollection<AnimeComment> AnimeComments { get; set; } = new List<AnimeComment>();
        public virtual ICollection<UserAnime> Animes { get; set; } = new List<UserAnime>();
        public virtual ICollection<AnimeCommentReaction> Reactions { get; set; } = new List<AnimeCommentReaction>();
    }
}
