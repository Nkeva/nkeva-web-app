using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Attributes;
using nkeva_web_app.Models;
using nkeva_web_app.Requests;
using nkeva_web_app.Responses;
using nkeva_web_app.Tools;
using System.Text.RegularExpressions;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

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
                Password = PasswordTool.HashPassword(password, out var salt),
                PasswordSalt = salt,
                School = school
            };

            user = (await DB.Users.AddAsync(user)).Entity;

            await DB.SaveChangesAsync();

            return Ok(new UserResponse(true, null, user));
        }

        [Authorize]
        [HttpGet("self")]
        public IActionResult GetSelfUser()
        {
            return Ok(new UserResponse(true, null, AuthUser));
        }

        [HttpPost("reset-password-email")]
        public async Task<IActionResult> SendResetUserPasswordEmail([FromBody] string email)
        {
            User? user = await DB.Users.SingleOrDefaultAsync(p => p.Email == email);

            if (user == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("User with the email not found.", null));
            }

            var mailMessage = new MimeMessage();

            mailMessage.From.Add(MailboxAddress.Parse("address"));
            mailMessage.To.Add(MailboxAddress.Parse(email));
            mailMessage.Subject = "Test subject!";
            mailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = "<html><body>Test</body></html>"
            };

            using var smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, SecureSocketOptions.Auto);
            smtpClient.Authenticate("address", "password");

            try
            {
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse.ErrorResponse(ex.Message, null));
            }

            return Ok(new BaseResponse.SuccessResponse(null, null));
        }

        [Authorize]
        [HttpPut("{userID}/password")]
        public async Task<IActionResult> ResetUserPassword(int userID, [FromBody] string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

            if (!regex.IsMatch(password))
            {
                return BadRequest(new BaseResponse.ErrorResponse("Password is not valid.", null));
            }

            User? user = await DB.Users.SingleOrDefaultAsync(p => p.Id == userID);

            if (user == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("User not found.", null));
            }

            user.Password = PasswordTool.HashPassword(password, out var salt);
            user.PasswordSalt = salt;

            await DB.SaveChangesAsync();

            return Ok(new UserResponse(true, null, user));
        }
    }
}
