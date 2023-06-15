using nkeva_web_app.Models;
using nkeva_web_app.Models.Interfaces;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class GroupChatResponse : BaseResponse
    {
        public GroupChatResponse(bool success, string? message, IChat data) : base(success, message, new Chat(data))
        {
        }

        public GroupChatResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class Chat
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonPropertyName("description")]
            public string? Description { get; set; }
            [JsonPropertyName("createdAt")]
            public DateTime CreatedAt { get; set; }
            [JsonPropertyName("owner")]
            public User? Owner { get; set; }
            [JsonPropertyName("school")]
            public School? School { get; set; }

            public Chat(IChat data)
            {
                Id = data.Id;
                Name = data.Name;
                Description = data.Description;
                CreatedAt = data.CreatedAt;
                Owner = data.Owner;
                School = data.School;
            }
        }
    }
}
