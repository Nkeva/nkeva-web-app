using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Models;
using nkeva_web_app.Requests;
using nkeva_web_app.Responses;
using nkeva_web_app.Services;

namespace nkeva_web_app.Controllers
{
    [Route("api/chats")]
    [Authorize]
    [ApiController]
    public class ChatController : BaseController
    {
        private readonly IFileStorageService fileStorage;

        public ChatController(DbApp context, IFileStorageService fileStorage) : base(context)
        {
            this.fileStorage = fileStorage;
        }

        // chats

        [HttpPost("private")]
        public async Task<IActionResult> CreatePrivateChat([FromBody] PrivateChatRequest request)
        {
            User? user1 = await DB.Users
                .Include(p => p.School)
                .Include(p => p.Role)
                .SingleOrDefaultAsync(p => p.Id == request.FirstUserId);

            if (user1 == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid first user id!", null));
            }

            User? user2 = await DB.Users
                .Include(p => p.School)
                .Include(p => p.Role)
                .SingleOrDefaultAsync(p => p.Id == request.SecondUserId);

            if (user2 == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid second user id!", null));
            }

            School? school = await DB.School.SingleOrDefaultAsync(p => p.Id == request.SchoolId);

            if (school?.Id != user1.SchoolId || school?.Id != user2.SchoolId)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid school id!", null));
            }

            Chat chat = (await DB.Chats.AddAsync(new Chat
            {
                SchoolId = school.Id,
                OwnerId = null,
                Owner = null,
                School = school
            })).Entity;

            await DB.ChatMembers.AddAsync(new ChatMember
            {
                ChatId = chat.Id,
                UserId = user1.Id,
                Chat = chat,
                User = user1
            });

            await DB.ChatMembers.AddAsync(new ChatMember
            {
                ChatId = chat.Id,
                UserId = user2.Id,
                Chat = chat,
                User = user2
            });

            await DB.SaveChangesAsync();

            return Ok(new PrivateChatResponse(true, null, chat, user1, user2));
        }

        [HttpPost("group")]
        public async Task<IActionResult> CreateGroupChat([FromBody] GroupChatRequest request)
        {
            User? owner = await DB.Users
                .Include(p => p.School)
                .Include(p => p.Role)
                .SingleOrDefaultAsync(p => p.Id == request.OwnerId);

            if (owner == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid owner id!", null));
            }

            School school = await DB.School.SingleAsync(p => p.Id == owner.SchoolId);

            Chat chat = (await DB.Chats.AddAsync(new Chat 
            {
                SchoolId = owner.SchoolId,
                OwnerId = owner.Id,
                Name = request.Name,
                Description = request.Description,
                Owner = owner,
                School = school
            })).Entity;

            await DB.SaveChangesAsync();

            return Ok(new GroupChatResponse(true, null, chat));
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetPrivateStudentChats()
        {
            var chats = await DB.ChatMembers
                .Where(p => p.UserId == AuthUser.Id)
                .Include(p => p.Chat)
                    .ThenInclude(p => p.ChatMembers)
                    .ThenInclude(p => p.User)
                    .ThenInclude(p => p.Role)
                .Where(
                    p => p.Chat.Owner == null &&
                    p.Chat.ChatMembers.Any(p => p.UserId != AuthUser.Id) &&
                    p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.Role.Name == "Student"
                 )
                .Select(p =>
                new {
                    Chat = p.Chat,
                    SecondUser = new {
                        Id = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.Id,
                        Role = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.Role,
                        FirstName = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.FirstName,
                        LastName = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.LastName,
                        MiddleName = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.MiddleName,
                        IsOnline = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.IsOnline,
                        IsBlocked = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.IsBlocked,
                        CreatedAt = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.CreatedAt,
                        UpdatedAt = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.UpdatedAt
                    }
                })
                .ToListAsync();

            return Ok(new BaseResponse.SuccessResponse(null, chats));
        }

        [HttpGet("teachers")]
        public async Task<IActionResult> GetPrivateTeacherChats()
        {
            var chats = await DB.ChatMembers
                .Where(p => p.UserId == AuthUser.Id)
                .Include(p => p.Chat)
                    .ThenInclude(p => p.ChatMembers)
                    .ThenInclude(p => p.User)
                    .ThenInclude(p => p.Role)
                .Where(
                    p => p.Chat.Owner == null &&
                    p.Chat.ChatMembers.Any(p => p.UserId != AuthUser.Id) &&
                    (p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.Role.Name == "Teacher" ||
                    p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.Role.Name == "HeadTeacher")
                 )
                .Select(p =>
                new {
                    Chat = p.Chat,
                    SecondUser = new
                    {
                        Id = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.Id,
                        Role = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.Role,
                        FirstName = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.FirstName,
                        LastName = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.LastName,
                        MiddleName = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.MiddleName,
                        IsOnline = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.IsOnline,
                        IsBlocked = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.IsBlocked,
                        CreatedAt = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.CreatedAt,
                        UpdatedAt = p.Chat.ChatMembers.Single(p => p.UserId != AuthUser.Id).User.UpdatedAt
                    }
                })
                .ToListAsync();

            return Ok(new BaseResponse.SuccessResponse(null, chats));
        }

        [HttpGet("groups")]
        public async Task<IActionResult> GetGroupChats()
        {
            var chats = await DB.ChatMembers
                .Where(p => p.UserId == AuthUser.Id)
                .Include(p => p.Chat)
                    .ThenInclude(p => p.ChatMembers)
                    .ThenInclude(p => p.User)
                    .ThenInclude(p => p.Role)
                .Where(
                    p => p.Chat.Owner != null
                 )
                .Select(p =>
                new {
                    Chat = p.Chat,
                    Users = p.Chat.ChatMembers
                })
                .ToListAsync();

            return Ok(new BaseResponse.SuccessResponse(null, chats));
        }

        [HttpDelete("{chatID}")]
        public async Task<IActionResult> DeleteChat(int chatID)
        {
            Chat? chat = await DB.Chats
                .Include(p => p.Owner)
                .Include(p => p.School)
                .SingleOrDefaultAsync(p => p.Id == chatID);

            if (chat == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            chat = DB.Chats.Remove(chat).Entity;

            await DB.SaveChangesAsync();

            return Ok(new GroupChatResponse(true, null, chat));
        }

        // chat members

        [HttpPost("{chatID}/users/{userID}")]
        public async Task<IActionResult> AddChatMember(int chatID, int userID)
        {
            Chat? chat = await DB.Chats
                .Include(p => p.Owner)
                .Include(p => p.School)
                .SingleOrDefaultAsync(p => p.Id == chatID);

            if (chat == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            if (chat.OwnerId == null)
            {
                return NotFound(new BaseResponse.ErrorResponse(
                    "Couldn't add the member because the chat is private!", 
                    null));
            }

            User? user = await DB.Users
                .Include(p => p.School)
                .Include(p => p.Role)
                .SingleOrDefaultAsync(p => p.Id == userID);

            if (user == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid user id!", null));
            }

            ChatMember member = (await DB.ChatMembers.AddAsync(new ChatMember
            {
                ChatId = chat.Id,
                UserId = user.Id,
                Chat = chat,
                User = user
            })).Entity;

            return Ok(new BaseResponse.SuccessResponse(null, member));
        }

        [HttpGet("{chatID}/users")]
        public async Task<IActionResult> GetChatMemberList(int chatID)
        {
            if ((await DB.Chats
                .Select(p => p.Id)
                .ContainsAsync(chatID))
                == false)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            List<User> users = await DB.ChatMembers
                .Include(p => p.User)
                .Where(p => p.ChatId == chatID)
                .Select(p => p.User)
                .ToListAsync();

            return Ok(new ListResponse<User>(true, null, users));
        }

        [HttpGet("{chatID}/users/{userID}")]
        public async Task<IActionResult> GetChatMember(int chatID, int userID)
        {
            if ((await DB.Chats
                .Select(p => p.Id)
                .ContainsAsync(chatID))
                == false)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            User? user = await DB.Users
                .Include(p => p.School)
                .Include(p => p.Role)
                .SingleOrDefaultAsync(p => p.Id == userID);

            if (user == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid user id!", null));
            }

            return Ok(new UserResponse(true, null, user));
        }

        [HttpPut("{chatID}/users/{userID}")]
        public async Task<IActionResult> ChangeChatOwner(int chatID, int userID)
        {
            Chat? chat = await DB.Chats
                .Include(p => p.Owner)
                .Include(p => p.School)
                .SingleOrDefaultAsync(p => p.Id == chatID);

            if (chat == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            if (chat.OwnerId == null)
            {
                return BadRequest(new BaseResponse.ErrorResponse("The chat is private!", null));
            }

            if (chat.OwnerId == userID)
            {
                return BadRequest(new BaseResponse.ErrorResponse("The user is the owner of the chat already!", null));
            }

            if ((await DB.ChatMembers
                .Where(p => p.ChatId == chatID)
                .Select(p => p.UserId)
                .ContainsAsync(userID))
                == false)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid user id!", null));
            }

            User user = await DB.Users
                .Include(p => p.School)
                .Include(p => p.Role)
                .SingleAsync(p => p.Id == userID);

            chat.OwnerId = user.Id;
            chat.Owner = user;

            await DB.SaveChangesAsync();

            return Ok(new UserResponse(true, null, user));
        }

        [HttpDelete("{chatID}/users/{userID}")]
        public async Task<IActionResult> DeleteChatMember(int chatID, int userID, [FromQuery] bool? deleteChatIfOne)
        {
            Chat? chat = await DB.Chats
                .Include(p => p.Owner)
                .Include(p => p.School)
                .SingleOrDefaultAsync(p => p.Id == chatID);

            if (chat == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            if (chat.OwnerId == null)
            {
                return BadRequest(new BaseResponse.ErrorResponse("The chat is private!", null));
            }

            ChatMember? member = await DB.ChatMembers
                .Include(p => p.Chat)
                .Include(p => p.User)
                .SingleOrDefaultAsync(p => p.ChatId == chatID && p.UserId == userID);

            if (member == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid user id!", null));
            }

            User user = await DB.Users
                .Include(p => p.School)
                .Include(p => p.Role)
                .SingleAsync(p => p.Id == userID);

            if ((await DB.ChatMembers.Where(p => p.ChatId == chatID).ToListAsync()).Count == 1)
            {
                if (deleteChatIfOne == true)
                {
                    DB.Chats.Remove(chat);

                    await DB.SaveChangesAsync();

                    return Ok(new UserResponse(true, null, user));
                }

                return BadRequest(new BaseResponse.ErrorResponse("The member can't be deleted!", null));
            }

            member = DB.ChatMembers.Remove(member).Entity;

            await DB.SaveChangesAsync();

            return Ok(new UserResponse(true, null, user));
        }

        // messages

        [HttpPost("{chatID}/messages")]
        public async Task<IActionResult> SendMessage(int chatID, [FromBody] PostMessageRequest request, IFormFileCollection files)
        {
            Chat? chat = await DB.Chats
                .Include(p => p.Owner)
                .Include(p => p.School)
                .SingleOrDefaultAsync(p => p.Id == chatID);

            if (chat == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            Message? replyMsg = await DB.Messages
                .Include(p => p.Chat)
                .Include(p => p.Sender)
                .Include(p => p.File)
                .Include(p => p.ReplyTo)
                .SingleOrDefaultAsync(p => p.Id == request.ReplyToId);

            if (replyMsg == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid replied message id!", null));
            }

            var msgFile = await DB.Files.AddAsync(new Models.File
            {
                Name = files[0].FileName,
                Size = files[0].Length,
                OwnerId = AuthUser.Id,
                SchoolId = SchoolUser.SchoolId
            });

            Message message = (await DB.Messages.AddAsync(new Message
            {
                ChatId = chatID,
                SenderId = SchoolUser.Id,
                Text = request.Text,
                FileId = msgFile.Entity.Id,
                ReplyToId = replyMsg.Id,
                Chat = chat,
                Sender = SchoolUser,
                File = msgFile.Entity,
                ReplyTo = replyMsg
            })).Entity;

            await DB.SaveChangesAsync();

            (await fileStorage.UploadFileAsync(msgFile.Entity, files[0].OpenReadStream())).Close();

            return Ok(new MessageResponse(true, null, message));
        }

        [HttpGet("{chatID}/messages")]
        public async Task<IActionResult> GetMessageListByChat(int chatID)
        {
            if ((await DB.Chats
                .Include(p => p.Owner)
                .Include(p => p.School)
                .SingleOrDefaultAsync(p => p.Id == chatID))
                == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid chat id!", null));
            }

            List<Message> messages = await DB.Messages
                .Include(p => p.Chat)
                .Include(p => p.Sender)
                .Include(p => p.File)
                .Include(p => p.ReplyTo)
                .Where(p => p.ChatId == chatID)
                .ToListAsync();

            return Ok(new ListResponse<Message>(true, null, messages));
        }

        [HttpGet("messages/{messageID}")]
        public async Task<IActionResult> GetMessage(int messageID)
        {
            Message? msg = await DB.Messages
                .Include(p => p.Chat)
                .Include(p => p.Sender)
                .Include(p => p.File)
                .Include(p => p.ReplyTo)
                .SingleOrDefaultAsync(p => p.Id == messageID);

            if (msg == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid message id!", null));
            }

            return Ok(new MessageResponse(true, null, msg));
        }

        [HttpPut("messages/{messageID}")]
        public async Task<IActionResult> EditMessage(int messageID, [FromBody] string newText)
        {
            Message? msg = await DB.Messages
                .Include(p => p.Chat)
                .Include(p => p.Sender)
                .Include(p => p.File)
                .Include(p => p.ReplyTo)
                .SingleOrDefaultAsync(p => p.Id == messageID);

            if (msg == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid message id!", null));
            }

            if (newText.Length > 0)
            {
                msg.Text = newText;
            }
            else
            {
                return BadRequest(new BaseResponse.ErrorResponse("The content is empty!", null));
            }

            await DB.SaveChangesAsync();

            return Ok(new MessageResponse(true, null, msg));
        }

        [HttpDelete("messages/{messageID}")]
        public async Task<IActionResult> DeleteMessage(int messageID)
        {
            Message? msg = await DB.Messages
                .Include(p => p.Chat)
                .Include(p => p.Sender)
                .Include(p => p.File)
                .Include(p => p.ReplyTo)
                .SingleOrDefaultAsync(p => p.Id == messageID);

            if (msg == null)
            {
                return NotFound(new BaseResponse.ErrorResponse("Invalid message id!", null));
            }

            if (msg.SenderId != AuthUser.Id)
            {
                return BadRequest(new BaseResponse.ErrorResponse("The user is not the sender of the message!", null));
            }

            Models.File? file = msg.File;

            if (file != null)
            {
                await fileStorage.DeleteFileAsync(file);
                DB.Files.Remove(file);
            }

            msg = DB.Messages.Remove(msg).Entity;

            await DB.SaveChangesAsync();

            return Ok(new MessageResponse(true, null, msg));
        }
    }
}
