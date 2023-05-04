namespace nkeva_web_app.Models
{
    public class SchoolRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
