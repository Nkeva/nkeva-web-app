namespace nkeva_web_app.Models
{
    public class StaffRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
    }
}
