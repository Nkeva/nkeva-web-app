using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using nkeva_web_app.Requests;
using nkeva_web_app.Responses;
using System.Data.Entity;

namespace nkeva_web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DbApp _context;
        public AuthController(DbApp context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new UserResponse(false, "Invalid login or password"));
            }

            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.GetFullName()),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim(ClaimTypes.System, user.SchoolId.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme)));
            return Ok(new UserResponse(true, null, user));
        }

        [HttpGet]
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
