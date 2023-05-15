using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Models;
using nkeva_web_app.Models.Anime;

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
            if (db.StaffRoles.Count() == 0)
            {
                db.StaffRoles.AddRange(new List<StaffRole>
                {
                    new StaffRole() {Name = "Admin"},
                    new StaffRole() {Name = "Developer"},
                    new StaffRole() {Name = "Manager"},
                    new StaffRole() {Name = "Accountant"},
                    new StaffRole() {Name = "Support"}
                });
            }
            db.SaveChanges();
            string hash = PasswordTool.HashPasword("admin", out byte[] salt);
            var admin = db.StaffRoles.Single(p => p.Name == "Admin");
            db.Staff.Add(new Staff()
            {
                Login = "admin",
                Password = hash,
                PasswordSalt = salt,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsBlocked = false,
                Role = admin,
                RoleId = admin.Id,
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


            db.AnimeFormats.AddRange(new List<AnimeFormat>()
            {
                new AnimeFormat() {Name = "TV"},
                new AnimeFormat() {Name = "TV Short"},
                new AnimeFormat() {Name = "Movie"},
                new AnimeFormat() {Name = "Music"}
            });

            db.AnimeGenres.AddRange(new List<AnimeGenre>
            {
                new AnimeGenre(){Name = "Action"},
                new AnimeGenre(){Name = "Adventure"},
                new AnimeGenre(){Name = "Comedy"},
                new AnimeGenre(){Name = "Drama"}
            });

            db.SaveChanges();
        }
    }
}
