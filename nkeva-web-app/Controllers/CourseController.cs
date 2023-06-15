using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Attributes;
using nkeva_web_app.Requests;
using nkeva_web_app.Responses;

namespace nkeva_web_app.Controllers
{
    [ApiController]
    [Route("api/сourse")]
    public class CourseController : BaseController
    {
        public CourseController(DbApp db) : base(db)
        {
        }

        [HttpPost]
        [HeadTeacherAuthorize]
        public async Task<IActionResult> PostCourse([FromBody] PostCourseRequest request)
        {
            if (await DB.Courses.AnyAsync(p => p.SchoolId == SchoolUser.Id && p.Name == request.Name))
            {
                return BadRequest(new BaseResponse.ErrorResponse("Name is already taken!", false));
            }

            var result = (await DB.Courses.AddAsync(new Models.Course()
            {
                Name = request.Name,
                Description = request.Description,
                School = SchoolUser.School
            })).Entity;

            return Ok(new CourseResponse(true, result));
        }

        [HttpPut("{id}")]
        [HeadTeacherAuthorize]
        public async Task<IActionResult> PutCourse([FromBody] PutCourseRequest request, int id)
        {
            var course = await DB.Courses.SingleOrDefaultAsync(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId);
            if (course is null)
            {
                return NotFound(new BaseResponse.ErrorResponse($"Courses [{id}] not found!", null));
            }

            if (request.Name is not null)
            {
                course.Name = request.Name;
            }

            if (request.Description is not null)
            {
                course.Description = request.Description;
            }

            await DB.SaveChangesAsync();

            return Ok(new CourseResponse(true, course));
        }

        [HttpDelete("{id}")]
        [HeadTeacherAuthorize]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = DB.Courses.SingleOrDefault(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId);
            if (course is null)
            {
                return NotFound(new BaseResponse.ErrorResponse($"Courses [{id}] not found!", null));
            }

            DB.Courses.Remove(course);
            await DB.SaveChangesAsync();

            return Ok(new CourseResponse(true, course));
        }

        [HttpGet]
        [HeadTeacherAuthorize]
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await DB.Courses.Where(p => p.SchoolId == SchoolUser.SchoolId).Select(p => new CourseResponse.Course(p)).ToArrayAsync();
            return Ok(new CourseResponse(true, result));
        }

        [HttpGet("my")]
        [HeadTeacherAuthorize]
        [TeacherAuthorize]
        [StudentAuthorize]
        [ParentAuthorize]
        public async Task<IActionResult> GetMyCourses()
        {
            var userCourse = await DB.Users.Include(p => p.Groups).ThenInclude(p => p.Courses).SingleAsync(p => p.SchoolId == SchoolUser.Id);
            var resulr = userCourse.Groups.Select(p => new
            {
                Group = new
                {
                    p.Id,
                    p.Name
                },
                Courses = p.Courses,
            });
            return Ok(new BaseResponse.SuccessResponse(null, resulr));
        }

    }
}
