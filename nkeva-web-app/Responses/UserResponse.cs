using System.Security.Claims;
using System.Text.Json.Serialization;

namespace nkeva_web_app.Responses
{
    public class UserResponse : BaseResponse
    {
        public UserResponse(bool success, string? message, User? data) : base(success, message, data)
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
            [JsonPropertyName("first_name")]
            public string FirstName { get; set; }
            [JsonPropertyName("last_name")]
            public string LastName { get; set; }
            [JsonPropertyName("surname")]
            public string? Surname { get; set; } = null;
            [JsonPropertyName("email")]
            public string? Email { get; set; } = null;
            [JsonPropertyName("phone")]
            public string? Phone { get; set; } = null;
            [JsonPropertyName("is_online")]
            public bool IsOnline { get; set; } = false;
            [JsonPropertyName("is_blocked")]
            public bool IsBlocked { get; set; } = false;
            [JsonPropertyName("created_at")]
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            [JsonPropertyName("updated_at")]
            public DateTime UpdatedAt { get; set; } = DateTime.Now;

            public static implicit operator UserResponse.User(Models.User user)
            {
                return new UserResponse.User
                {
                    Id = user.Id,
                    Login = user.Login,
                    Role = user.Role.Name,
                    School = user.SchoolId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Surname = user.Surname,
                    Email = user.Email,
                    Phone = user.Phone,
                    IsOnline = user.IsOnline,
                    IsBlocked = user.IsBlocked,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt
                };
            }

            
        }
    }
}
