namespace nkeva_web_app.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? FileId { get; set; }
        public int AnswerId { get; set; }
        public int WriterId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual File? File { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual User Writer { get; set; }
    }
}
