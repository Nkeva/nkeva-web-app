using Microsoft.AspNetCore.Authorization;
using nkeva_web_app.Models.Enums;
using System.Security.Claims;

namespace nkeva_web_app.Attributes
{
    public class SchoolRoleHandler : AuthorizationHandler<SchoolRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SchoolRoleRequirement requirement)
        {
            if (context.User.FindFirstValue("user_type") == UserType.School.ToString())
            {
                string role = context.User.FindFirstValue(ClaimTypes.Role);
                if (context.User.IsInRole(requirement.Role) 
                    || context.User.IsInRole("Admin") 
                    || (role == "HeadTeacher" && requirement.Role == "Teacher"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
