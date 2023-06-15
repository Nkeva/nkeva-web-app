using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Attributes;
using nkeva_web_app.Models;
using nkeva_web_app.Requests;
using nkeva_web_app.Responses;
using nkeva_web_app.Tools;

namespace nkeva_web_app.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(DbApp db) : base(db)
        {
        }

        [AdminAuthorize]
        [HeadTeacherAuthorize]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var role = await DB.UsersSchoolRoles.SingleOrDefaultAsync(x => x.Name == request.Role);
            if (role == null)
            {
                return BadRequest(new BaseResponse.ErrorResponse("Invalid Role", null));
            }
            if (role.Id >= SchoolUser.RoleId)
            {
                return BadRequest(new BaseResponse.ErrorResponse("Insufficient Rights", null));
            }

            var school = await DB.School.SingleOrDefaultAsync(p => p.Id == SchoolUser.SchoolId);

            if (school == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("School Not Found", null));
            }

            var password = PasswordTool.GenerateRandomPassword(8);

            var user = new User()
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                IsBlocked = request.IsBlocked,
                Role = role,
                Password = PasswordTool.HashPasword(password, out var salt),
                PasswordSalt = salt,
                Login = StringTool.Transliterate(request.LastName) + "_" + StringTool.RandomString(6),
                School = school
            };

            user = (await DB.Users.AddAsync(user)).Entity;

            await DB.SaveChangesAsync();

            return Ok(new UserResponse(true, null, user));
        }
    }
}
