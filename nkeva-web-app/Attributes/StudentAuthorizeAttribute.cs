using Microsoft.AspNetCore.Authorization;

namespace nkeva_web_app.Attributes
{
    public class StudentAuthorizeAttribute : AuthorizeAttribute
    {
        public StudentAuthorizeAttribute()
        {
            Policy = "SchoolRole_Student";
        }
    }
}
