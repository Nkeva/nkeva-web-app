using nkeva_web_app.Models;
using nkeva_web_app.Models.Interfaces;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class MessageResponse : BaseResponse
    {
        public MessageResponse(bool success, string? message, IMessage data) : base(success, message, new Msg(data))
        {
        }

        public MessageResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class Msg
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("text")]
            public string Text { get; set; }
            [JsonPropertyName("isChanged")]
            public bool IsChanged { get; set; }
            [JsonPropertyName("isRead")]
            public bool IsRead { get; set; }
            [JsonPropertyName("cratedAt")]
            public DateTime CreatedAt { get; set; }
            [JsonPropertyName("chat")]
            public Chat Chat { get; set; }
            [JsonPropertyName("sender")]
            public User Sender { get; set; }
            [JsonPropertyName("file")]
            public Models.File? File { get; set; }
            [JsonPropertyName("replyTo")]
            public Models.Message? ReplyTo { get; set; }

            public Msg(IMessage data)
            {
                Id = data.Id;
                Text = data.Text;
                IsChanged = data.IsChanged;
                IsRead = data.IsRead;
                CreatedAt = data.CreatedAt;
                Chat = data.Chat;
                Sender = data.Sender;
                File = data.File;
                ReplyTo = data.ReplyTo;
            }
        }
    }
}
