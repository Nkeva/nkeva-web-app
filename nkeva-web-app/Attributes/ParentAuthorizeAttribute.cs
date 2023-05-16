using Microsoft.AspNetCore.Authorization;

namespace nkeva_web_app.Attributes
{
    public class ParentAuthorizeAttribute : AuthorizeAttribute
    {
        public ParentAuthorizeAttribute()
        {
            Policy = "SchoolRole_Parent";
        }
    }
}
