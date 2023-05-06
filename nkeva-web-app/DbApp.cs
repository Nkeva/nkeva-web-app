using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Models;

namespace nkeva_web_app
{
    public class DbApp : DbContext
    {
        public DbApp(DbContextOptions<DbApp> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Tables for staff
        public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<Staff> Staff { get; set; }

        // Tables for school system
        public DbSet<School> School { get; set; }
        public DbSet<SchoolRole> UsersSchoolRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<TimetableRecordType> TimetableRecordTypes { get; set; }
        public DbSet<TimetableRecord> TimetableRecords { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // Tables for chating
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region ChatMember

            modelBuilder.Entity<ChatMember>()
                .HasKey(c => new { c.ChatId, c.UserId });

            modelBuilder.Entity<ChatMember>()
                .HasOne(cm => cm.Chat)
                .WithMany(c => c.ChatMembers)
                .HasForeignKey(cm => cm.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChatMember>()
                .HasOne(cm => cm.User)
                .WithMany(u => u.ChatMembers)
                .HasForeignKey(cm => cm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Chat

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.School)
                .WithMany(s => s.Chats)
                .HasForeignKey(c => c.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Course

            modelBuilder.Entity<Course>()
                .HasOne(c => c.School)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Groups)
                .WithMany(g => g.Courses);

            #endregion

            #region Message

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.File)
                .WithMany(f => f.Messages)
                .HasForeignKey(m => m.FileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ReplyTo)
                .WithMany(m => m.Replies)
                .HasForeignKey(m => m.ReplyToId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Meeting

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Creator)
                .WithMany(u => u.Meetings)
                .HasForeignKey(m => m.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region File

            modelBuilder.Entity<Models.File>()
                .HasOne(f => f.Owner)
                .WithMany(u => u.Files)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Models.File>()
                .HasOne(f => f.School)
                .WithMany(s => s.Files)
                .HasForeignKey(f => f.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Group

            modelBuilder.Entity<Group>()
                .HasOne(g => g.School)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(u => u.Groups);

            #endregion

            #region Timetable record

            modelBuilder.Entity<TimetableRecord>()
                .HasOne(tr => tr.Group)
                .WithMany(g => g.TimetableRecords)
                .HasForeignKey(tr => tr.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimetableRecord>()
                .HasOne(tr => tr.School)
                .WithMany(s => s.TimetableRecords)
                .HasForeignKey(tr => tr.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimetableRecord>()
                .HasOne(tr => tr.Teacher)
                .WithMany(m => m.TimetableRecords)
                .HasForeignKey(tr => tr.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimetableRecord>()
                .HasOne(tr => tr.Course)
                .WithMany(c => c.TimetableRecords)
                .HasForeignKey(tr => tr.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimetableRecord>()
                .HasOne(tr => tr.Meeting)
                .WithMany(m => m.TimetableRecords)
                .HasForeignKey(tr => tr.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimetableRecord>()
                .HasOne(tr => tr.Type) 
                .WithMany(c => c.TimetableRecords)
                .HasForeignKey(tr => tr.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Tasks

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Tasks)
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.School)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.File)
                .WithMany(f => f.Tasks)
                .HasForeignKey(t => t.FileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.TimetableRecord)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.TimetableRecordId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.TaskType)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.TaskTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Visit

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Student)
                .WithMany(u => u.Visits)
                .HasForeignKey(v => v.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.TimetableRecord)
                .WithMany(tr => tr.Visits)
                .HasForeignKey(v => v.TimetableRecordId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Answer

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Student)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Task)
                .WithMany(t => t.Answers)
                .HasForeignKey(a => a.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.File)
                .WithMany(f => f.Answers)
                .HasForeignKey(a => a.FileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.School)
                .WithMany(s => s.Answers)
                .HasForeignKey(a => a.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Comment

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Writer)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.WriterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Answer)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.File)
                .WithMany(f => f.Comments)
                .HasForeignKey(c => c.FileId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region User

            modelBuilder.Entity<User>()
                .HasOne(u => u.School)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(sr => sr.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();

            #endregion

            #region Staff

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.StaffRole)
                .WithMany(sr => sr.Staff)
                .HasForeignKey(s => s.StaffRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region School Roles

            modelBuilder.Entity<SchoolRole>()
                .HasIndex(sr => sr.Name)
                .IsUnique();

            #endregion

            #region Staff Roles

            modelBuilder.Entity<StaffRole>()
                .HasIndex(sr => sr.Name)
                .IsUnique();

            #endregion
        }
    }
}
