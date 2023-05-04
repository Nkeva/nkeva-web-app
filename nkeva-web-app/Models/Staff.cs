namespace nkeva_web_app.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Surname { get; set; }
        public int StaffRoleId { get; set; }
        public bool IsActivated { get; set; }
        public bool IsOnline { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual StaffRole StaffRole { get; set; }
    }
}
