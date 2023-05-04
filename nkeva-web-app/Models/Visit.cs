namespace nkeva_web_app.Models
{
    public class Visit
    {
        public enum VisitType
        {
            Present = 0,
            Absent = 10,
            Late = 20
        }

        public int Id { get; set; }
        public VisitType Type { get; set; }
        public int Points { get; set; }
        public int? Mark { get; set; }
        public string? Comment { get; set; }
        public int StudentId { get; set; }
        public int TimetableRecordId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual User Student { get; set; }
        public virtual TimetableRecord TimetableRecord { get; set; }
    }
}
