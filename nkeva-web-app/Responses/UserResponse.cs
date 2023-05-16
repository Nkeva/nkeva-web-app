using nkeva_web_app.Models.Interfaces;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class UserResponse : BaseResponse
    {
        public UserResponse(bool success, string? message, IUser? data) : base(success, message, data != null ? new User(data) : null)
        {
        }

        public UserResponse(bool success, string? message, ClaimsPrincipal data) : base(success, message, data)
        {
        }
        public UserResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public class User
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("login")]
            public string Login { get; set; }
            [JsonPropertyName("role")]
            public string Role { get; set; }
            [JsonPropertyName("school")]
            public int School { get; set; }
            [JsonPropertyName("firstName")]
            public string FirstName { get; set; }
            [JsonPropertyName("lastName")]
            public string LastName { get; set; }
            [JsonPropertyName("surname")]
            public string? Surname { get; set; } = null;
            [JsonPropertyName("email")]
            public string? Email { get; set; } = null;
            [JsonPropertyName("phone")]
            public string? Phone { get; set; } = null;
            [JsonPropertyName("isOnline")]
            public bool IsOnline { get; set; } = false;
            [JsonPropertyName("isBlocked")]
            public bool IsBlocked { get; set; } = false;
            [JsonPropertyName("createdAt")]
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            [JsonPropertyName("updatedAt")]
            public DateTime UpdatedAt { get; set; } = DateTime.Now;

            public User(IUser user)
            {
                Id = user.Id;
                Login = user.Login;
                Role = user.UserRole.Name;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Surname = user.MiddleName;
                Email = user.Email;
                Phone = user.PhoneNumber;
                IsOnline = user.IsOnline;
                IsBlocked = user.IsBlocked;
                CreatedAt = user.CreatedAt;
                UpdatedAt = user.UpdatedAt;
            }
        }
    }
}
