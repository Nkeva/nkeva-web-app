using Microsoft.AspNetCore.Authorization;
using nkeva_web_app.Models.Enums;
using System.Security.Claims;

namespace nkeva_web_app.Attributes
{
    public class OnlyStaffHandler : AuthorizationHandler<SchoolRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SchoolRoleRequirement requirement)
        {
            if(context.User.FindFirstValue("user_type") == UserType.Staff.ToString())
            {
                context.Succeed(requirement);
            }
            context.Fail();
            return Task.CompletedTask;
        }
    }
}
