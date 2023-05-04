namespace nkeva_web_app.Models
{
    public class TaskType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
