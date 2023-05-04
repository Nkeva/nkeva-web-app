namespace nkeva_web_app.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Text { get; set; }
        public int? FileId { get; set; }
        public int? Mark { get; set; }
        public int TaskId { get; set; }
        public int StudentId { get; set; }
        public DateTime? CheckDate { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual School School { get; set; }
        public virtual File? File { get; set; }
        public virtual Tasks Task { get; set; }
        public virtual User Student { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
