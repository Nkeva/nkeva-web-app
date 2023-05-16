using Microsoft.AspNetCore.Authorization;

namespace nkeva_web_app.Attributes
{
    public class TeacherAuthorizeAttribute : AuthorizeAttribute
    {
        public TeacherAuthorizeAttribute()
        {
            Policy = "SchoolRole_Teacher";
        }
    }
}
