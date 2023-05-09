namespace nkeva_web_app.Models.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public int RoleId { get; set; }
        public IRole UserRole { get; }
        public bool IsBlocked { get; set; }
        public bool IsOnline { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}{(MiddleName == null ? "" : $" {MiddleName}")}";
        }
    }
}
