namespace nkeva_web_app.Models.Interfaces
{
    public interface IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
