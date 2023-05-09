using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Models;
using nkeva_web_app.Models.Enums;
using nkeva_web_app.Models.Interfaces;
using System.Security.Claims;

namespace nkeva_web_app.Controllers
{
    public class BaseController : ControllerBase
    {
        private IUser? _user;
        private UserType _userType;
        private object? _userObj;

        protected DbApp DB { get; }

        /// <summary>
        /// Return current authorized user or null if user not authorized
        /// </summary>
        protected IUser? AuthUser { 
            get
            {
                var strId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
                if(!int.TryParse(strId, out int id))
                {
                    return null;
                }
                var strType = HttpContext.User.Claims.FirstOrDefault(p => p.Type == "user_type")?.Value;
                if(strType == null)
                {
                    return null;
                }
                UserType type = (UserType)Enum.Parse(typeof(UserType), strType);
                _userType = type;
                if (type == UserType.Staff)
                {
                    _userObj = Task.FromResult(DB.Staff.SingleOrDefaultAsync(p => p.Id == id));
                }
                else
                {
                    _userObj = Task.FromResult(DB.Users.SingleOrDefaultAsync(p => p.Id == id));
                }
                _user = (IUser)_userObj;
                return _user;
            }
        }

        protected User? SchoolUser => _userType == UserType.School ? _userObj as User : null;
        protected Staff? StaffUser => _userType == UserType.Staff ? _userObj as Staff : null;
        protected UserType AuthUserType => _userType;

        public BaseController(DbApp db)
        {
            DB = db;
        }
    }
}
