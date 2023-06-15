namespace nkeva_web_app.Responses
{
    public class CourseResponse : BaseResponse
    {
        public CourseResponse(bool success, string? message, Models.Course data) : base(success, message, new Course(data))
        {
        }

        public CourseResponse(bool success, Models.Course data) : base(success, null, new Course(data))
        {
        }

        public CourseResponse(bool success, Course data) : base(success, null, data)
        {
        }

        public CourseResponse(bool success, ICollection<Course> data) : base(success, null, data)
        {
        }

        public class Course
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string? Description { get; set; } = null!;
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            
            public int SchoolId { get; set; }

            public Course(Models.Course course)
            {
                Id = course.Id;
                Name = course.Name;
                Description = course.Description;
                CreatedAt = course.CreatedAt;
                UpdatedAt = course.UpdatedAt;
                SchoolId = course.SchoolId;
            }
        }
    }
}
