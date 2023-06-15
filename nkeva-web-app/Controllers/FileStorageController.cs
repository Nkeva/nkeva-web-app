using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Responses;
using nkeva_web_app.Services;

namespace nkeva_web_app.Controllers
{
    [Route("api/fs")]
    [ApiController]
    public class FileStorageController : BaseController
    {
        private readonly IFileStorageService _fileStorageService;
        public FileStorageController(DbApp db, IFileStorageService fileStorageService) : base(db)
        {
            _fileStorageService = fileStorageService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFileAsync(int id)
        {
            var file = await DB.Files
                .Include(p => p.Answers).ThenInclude(p => p.Task).ThenInclude(p => p.TimetableRecord)
                .Include(p => p.Tasks).ThenInclude(p => p.TimetableRecord)
                .Include(p => p.Tasks).ThenInclude(p => p.Group).ThenInclude(p => p.Users)
                .Include(p => p.Messages).ThenInclude(p => p.Chat).ThenInclude(p => p.ChatMembers)
                .SingleOrDefaultAsync(p => p.Id == id);
            if (file is null)
            {
                return NotFound(new BaseResponse.ErrorResponse("File not found!", null));
            }

            if (file.SchoolId is not null)
            {
                if (SchoolUser?.SchoolId != file.SchoolId)
                {
                    return Unauthorized();
                }
                if(file.Answers.Count == 1)
                {
                    var answer = file.Answers.First();
                    if(!(answer.Task.TimetableRecord.TeacherId == SchoolUser.Id || answer.StudentId == SchoolUser.Id))
                    {
                        return Unauthorized();
                    }
                }
                if (file.Tasks.Count == 1)
                {
                    var task = file.Tasks.First();
                    if(!(task.TimetableRecord.TeacherId == SchoolUser.Id || task.Group.Users.Any(p => p.Id == SchoolUser.Id)))
                    {
                        return Unauthorized();
                    }
                }
                if (file.Messages.Count == 1)
                {
                    var message = file.Messages.First();
                    if (!message.Chat.ChatMembers.Any(p => p.UserId == SchoolUser.Id))
                    {
                        return Unauthorized();
                    }
                }
            }

            var fileStream = await _fileStorageService.DownloadFileAsync(file);
            return File(fileStream, "application/octet-stream", file.Name, true);
        }
    }
}
