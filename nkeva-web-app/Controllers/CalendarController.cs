using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nkeva_web_app.Controllers
{
    [Route("api/calendar")]
    [Authorize]
    [ApiController]
    public class CalendarController : BaseController
    {
        public CalendarController(DbApp context) : base(context)
        {
        }
    }
}
