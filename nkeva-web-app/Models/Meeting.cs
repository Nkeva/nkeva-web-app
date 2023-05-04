namespace nkeva_web_app.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual User Creator { get; set; }

        public virtual ICollection<TimetableRecord> TimetableRecords { get; set; } = new List<TimetableRecord>();
    }
}
