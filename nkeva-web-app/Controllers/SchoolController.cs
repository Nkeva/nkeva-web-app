using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Attributes;
using nkeva_web_app.Requests;
using nkeva_web_app.Responses;
using nkeva_web_app.Tools;

namespace nkeva_web_app.Controllers
{
    [OnlyStaffAuthorize]
    [Route("api/school")]
    [ApiController]
    public class SchoolController : BaseController
    {
        public SchoolController(DbApp db) : base(db)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PostSchoolRequest request)
        {
            try
            {
                var result = await DB.School.AddAsync(new Models.School()
                {
                    Name = request.Name,
                    Address = request.Address,
                    City = request.City,
                    Country = request.Country,
                    ZipCode = request.ZipCode,
                    Phone = request.Phone,
                    Email = request.Email,
                    Active = request.Active,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                await DB.SaveChangesAsync();

                var schoolAdmin = await DB.Users.AddAsync(new Models.User()
                {
                    Password = PasswordTool.HashPasword(request.Password, out var salt),
                    PasswordSalt = salt,
                    RoleId = 1,
                    School = result.Entity,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                await DB.SaveChangesAsync();

                return Ok(new SchoolResponse(result.Entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse.ErrorResponse(ex.Message, null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await DB.School.ToListAsync();
                return Ok(result.Select(x => new SchoolResponse(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse.ErrorResponse(ex.Message, null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutSchoolRequest request)
        {
            try
            {
                var school = await DB.School.SingleOrDefaultAsync(s => s.Id == request.Id);
                if (school == null)
                {
                    return NotFound(new BaseResponse.ErrorResponse("Not Found", null));
                }

                if (request.Name is not null && request.Name != school.Name)
                {
                    school.Name = request.Name;
                }

                if (request.Address is not null && request.Address != school.Address)
                {
                    school.Address = request.Address;
                }

                if (request.City is not null && request.City != school.City)
                {
                    school.City = request.City;
                }

                if (request.Country is not null && request.Country != school.Country)
                {
                    school.Country = request.Country;
                }

                if (request.ZipCode is not null && request.ZipCode != school.ZipCode)
                {
                    school.ZipCode = request.ZipCode;
                }

                if (request.Phone is not null && request.Phone != school.Phone)
                {
                    school.Phone = request.Phone;
                }

                if (request.Email is not null && request.Email != school.Email)
                {
                    school.Email = request.Email;
                }

                if (request.Active is not null && request.Active != school.Active)
                {
                    school.Active = request.Active == true;
                }

                school.UpdatedAt = DateTime.UtcNow;

                await DB.SaveChangesAsync();

                return Ok(new SchoolResponse(school));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse.ErrorResponse(ex.Message, null));
            }
        }

        //! TODO: Delete all students and classes
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSchoolRequest request)
        {
            var school = await DB.School.SingleOrDefaultAsync(s => s.Id == request.Id);
            if (school == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Not Found", null));
            }

            if (!PasswordTool.VerifyPassword(request.UserPassword, StaffUser.Password, StaffUser.PasswordSalt))
            {
                return Unauthorized(new BaseResponse.ErrorResponse("Invalid password", null));
            }

            DB.School.Remove(school);
            await DB.SaveChangesAsync();

            return Ok(new SchoolResponse(school));
        }

    }
}
