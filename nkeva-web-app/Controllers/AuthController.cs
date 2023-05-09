using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using nkeva_web_app.Requests;
using nkeva_web_app.Responses;
using nkeva_web_app.Models.Enums;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Models.Interfaces;
using nkeva_web_app.Models;

namespace nkeva_web_app.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(DbApp context) : base(context) 
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            List<Claim> claims = new List<Claim>();
            UserType type = UserType.Staff;
            // try to find user in school users
            IUser? user = await DB.Users.FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == request.Password);

            if (user == null)
            {
                // try to find user in staff
                user = await DB.Staff.FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == request.Password);

                // if user not found
                if(user == null)
                {
                    return Unauthorized(new UserResponse(false, "Invalid login or password"));
                }
                // if user found, set type to staff
                type = UserType.Staff;
            }
            else
            {
                // if user found, set type to school
                type = UserType.School;
            }

            // if user is blocked
            if (user.IsBlocked == true)
            {
                return Unauthorized(new UserResponse(false, "User is blocked"));
            }

            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.GetFullName()),
                new Claim(ClaimTypes.Role, user.UserRole.Name),
                new Claim("user_type", type.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme)));
            return Ok(new UserResponse(true, null, user));
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return Ok();
        }

        [HttpGet("check")]
        public IActionResult Check()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return Ok(new UserResponse(true, null, User));
            }
            return Unauthorized(new UserResponse(false, "Unauthorized"));
        }
    }
}
