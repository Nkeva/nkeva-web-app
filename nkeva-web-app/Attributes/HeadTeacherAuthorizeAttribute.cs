using Microsoft.AspNetCore.Authorization;

namespace nkeva_web_app.Attributes
{
    public class HeadTeacherAuthorizeAttribute : AuthorizeAttribute
    {
        public HeadTeacherAuthorizeAttribute()
        {
            Policy = "SchoolRole_HeadTeacher";
        }
    }
}
