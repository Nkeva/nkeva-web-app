using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Models;

namespace nkeva_web_app.Tools
{
    public static class InitSystem
    {
        private static bool isFirstStart = true;

        public static void Init(DbApp db)
        {
            if (isFirstStart)
            {
                isFirstStart = db.Staff.Count() == 0;
                if (isFirstStart)
                {
                    InitDatabase(db);
                    isFirstStart = false;
                }
            }
        }

        private static void InitDatabase(DbApp db)
        {
            db.StaffRoles.AddRange(new List<StaffRole>
            {
                new StaffRole() {Name = "Admin"},
                new StaffRole() {Name = "Developer"},
                new StaffRole() {Name = "Manager"},
                new StaffRole() {Name = "Accountant"},
                new StaffRole() {Name = "Support"}
            });
            string hash = PasswordTool.HashPasword("admin", out byte[] salt);
            db.Staff.Add(new Staff()
            {
                Login = "admin",
                Password = hash,
                PasswordSalt = salt,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsBlocked = false,
                RoleId = db.StaffRoles.Single(p => p.Name == "Admin").Id,
                LastName = "Sys",
                FirstName = "Admin",
                PhoneNumber = "1234567890",
                Email = "email@server.com"
            });

            db.UsersSchoolRoles.AddRange(new List<SchoolRole>()
            {
                new SchoolRole() {Name = "Admin"},
                new SchoolRole() {Name = "HeadTeacher"},
                new SchoolRole() {Name = "Teacher"},
                new SchoolRole() {Name = "Student"},
                new SchoolRole() {Name = "Parent"}
            });
            db.SaveChanges();
        }
    }
}
