using Microsoft.AspNetCore.Authorization;

namespace nkeva_web_app.Attributes
{
    public class SchoolRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }

        public SchoolRoleRequirement(string role)
        {
            Role = role;
        }
    }
}
