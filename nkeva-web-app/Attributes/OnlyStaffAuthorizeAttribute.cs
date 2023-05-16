using Microsoft.AspNetCore.Authorization;

namespace nkeva_web_app.Attributes
{
    public class OnlyStaffAuthorizeAttribute : AuthorizeAttribute
    {
        public OnlyStaffAuthorizeAttribute()
        {
            Policy = "OnlyStaff";
        }
    }
}
