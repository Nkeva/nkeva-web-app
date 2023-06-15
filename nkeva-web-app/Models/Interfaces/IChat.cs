namespace nkeva_web_app.Models.Interfaces
{
    public interface IChat
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int? OwnerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User? Owner { get; set; }
        public School School { get; set; }
    }
}
