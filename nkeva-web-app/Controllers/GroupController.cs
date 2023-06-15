using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Attributes;
using nkeva_web_app.Models;
using nkeva_web_app.Requests;
using nkeva_web_app.Responses;

namespace nkeva_web_app.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/group")]
    public class GroupController : BaseController
    {
        public GroupController(DbApp db) : base(db)
        {
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await DB.Groups.Where(g => g.SchoolId == SchoolUser.SchoolId)
                    .Include(p => p.Teacher).ThenInclude(p => p.Role)
                    .Select(p => new GroupResponse.Group(p))
                    .ToListAsync();
            return Ok(new GroupResponse(true, groups));
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] PostGroupRequest request)
        {
            var teacher = await DB.Users.Where(u => u.SchoolId == SchoolUser.SchoolId && u.Id == request.TeacherId)
                .SingleOrDefaultAsync();
            if (teacher == null)
                return NotFound(new GroupResponse(false, "Teacher not found"));

            if (await DB.Groups.AnyAsync(g => g.SchoolId == SchoolUser.SchoolId && g.Name == request.Name))
                return BadRequest(new GroupResponse(false, "Group with this name already exists"));

            var group = new Group
            {
                Name = request.Name,
                Teacher = teacher,
                Active = request.Active,
                IsSubGroup = request.IsSubGroup
            };

            group = (await DB.Groups.AddAsync(group)).Entity;

            await DB.SaveChangesAsync();

            return Ok(new GroupResponse(true, group));
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            var group = await DB.Groups.Where(g => g.SchoolId == SchoolUser.SchoolId && g.Id == id)
                .Include(p => p.Teacher).ThenInclude(p => p.Role)
                .SingleOrDefaultAsync();
            if (group == null)
                return NotFound(new GroupResponse(false, "Group not found"));
            return Ok(new GroupResponse(true, group));
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, [FromBody] PutGroupRequest request)
        {
            var group = await DB.Groups.Where(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId).FirstOrDefaultAsync();
            if (group == null)
                return NotFound(new GroupResponse(false, "Group not found"));

            if (request.Name is not null && group.Name != request.Name)
            {
                if (await DB.Groups.AnyAsync(g => g.SchoolId == SchoolUser.SchoolId && g.Name == request.Name))
                    return BadRequest(new GroupResponse(false, "Group with this name already exists"));
                group.Name = request.Name;
            }
            if (request.TeacherId is not null && group.TeacherId != request.TeacherId)
            {
                var teacher = await DB.Users.Where(u => u.SchoolId == SchoolUser.SchoolId && u.Id == request.TeacherId)
                                            .SingleOrDefaultAsync();
                if (teacher == null)
                    return NotFound(new GroupResponse(false, "Teacher not found"));
                group.TeacherId = teacher.Id;
                group.Teacher = teacher;
            }
            group.Active = request.Active;
            group.IsSubGroup = request.IsSubGroup;

            await DB.SaveChangesAsync();

            return Ok(new GroupResponse(true, group));
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await DB.Groups.Where(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId).FirstOrDefaultAsync();
            if (group == null)
                return NotFound(new GroupResponse(false, "Group not found"));

            DB.Groups.Remove(group);

            return Ok();
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [TeacherAuthorize]
        [StudentAuthorize]
        [HttpGet("my")]
        public async Task<IActionResult> GetMyGroups()
        {
            var groups = await DB.Groups.Include(p => p.Users).Where(g => g.SchoolId == SchoolUser.SchoolId && g.Users.Any(s => s.Id == SchoolUser.Id))
                .Include(p => p.Teacher).ThenInclude(p => p.Role)
                .Select(p => new GroupResponse.Group(p)).ToListAsync();
            return Ok();
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [TeacherAuthorize]
        [StudentAuthorize]
        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetGroupStudents(int id)
        {
            Group? group = await DB.Groups
                .Include(p => p.Teacher)
                .Include(p => p.Users)
                .SingleOrDefaultAsync(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId);

            if (group == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid group id!", null));
            }

            var students = group.Users.Select(p => new UserResponse.ShortUser(p)).ToList();

            return Ok(new ListResponse<UserResponse.ShortUser>(true, null, students));
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpPost("{id}/students")]
        public async Task<IActionResult> AddStudentsToGroup(int id, [FromBody] PostStudentsToGroupRequest request)
        {
            var group = await DB.Groups
                .Include(p => p.Users)
                .SingleOrDefaultAsync(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId);
            if (group == null)
                return NotFound(new GroupResponse(false, "Group not found"));

            foreach(var userId in request.Ids)
            {
                if (group.Users.Any(p => p.Id == userId))
                    continue;
                var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == userId && p.SchoolId == SchoolUser.Id);
                if (user == null)
                {
                    return NotFound(new BaseResponse.ErrorResponse("User not found!", null));
                }
                group.Users.Add(user);
            }

            await DB.SaveChangesAsync();

            return Ok();
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpDelete("{id}/students/{studentId}")]
        public async Task<IActionResult> RemoveStudentFromGroup(int id, int studentId)
        {
            var group = await DB.Groups
                .Include(p => p.Users)
                .SingleOrDefaultAsync(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId);
            if (group == null)
                return NotFound(new GroupResponse(false, "Group not found"));
            var student = await DB.Users.SingleOrDefaultAsync(p => p.Id == studentId && p.SchoolId == SchoolUser.SchoolId);
            if (student == null)
                return NotFound(new GroupResponse(false, "Student not found"));
            if (!group.Users.Any(p => p.Id == studentId))
                return NotFound(new GroupResponse(false, $"{studentId} was removed"));
            group.Users.Remove(student);

            await DB.SaveChangesAsync();

            return Ok();
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [TeacherAuthorize]
        [StudentAuthorize]
        [HttpGet("{id}/teacher")]
        public async Task<IActionResult> GetGroupTeacher(int id)
        {
            Group? group = await DB.Groups
                .Include(p => p.Teacher)
                .SingleOrDefaultAsync(p => p.Id == id && p.SchoolId == SchoolUser.SchoolId);

            if (group == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid group id!", null));
            }

            return Ok(new BaseResponse.SuccessResponse(null, new UserResponse.ShortUser(group.Teacher)));
        }
    }
}
