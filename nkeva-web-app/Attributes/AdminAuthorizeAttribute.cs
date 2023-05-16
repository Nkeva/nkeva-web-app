using Microsoft.AspNetCore.Authorization;

namespace nkeva_web_app.Attributes
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public AdminAuthorizeAttribute()
        {
            Policy = "SchoolRole_Admin";
        }
    }
}
