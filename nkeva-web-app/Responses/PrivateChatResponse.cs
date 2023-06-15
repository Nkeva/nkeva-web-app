using nkeva_web_app.Models;
using nkeva_web_app.Models.Interfaces;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class PrivateChatResponse : BaseResponse
    {
        public PrivateChatResponse(bool success, string? message, Chat? chat, User? firstUser, User? secondUser) : base(success, message, new Obj(chat, firstUser, secondUser))
        {
        }

        public PrivateChatResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class Obj
        {
            [JsonPropertyName("chat")]
            public Chat? Chat { get; set; }
            [JsonPropertyName("firstUser")]
            public User? FirstUser { get; set; }
            [JsonPropertyName("secondUser")]
            public User? SecondUser { get; set; }

            public Obj(Chat? chat, User? firstUser, User? secondUser)
            {
                Chat = chat;
                FirstUser = firstUser;
                SecondUser = secondUser;
            }
        }
    }
}
