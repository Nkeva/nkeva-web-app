namespace nkeva_web_app.Responses
{
    public class GroupResponse : BaseResponse
    {
        public GroupResponse(bool success, string? message, Models.Group data) : base(success, message, new Group(data))
        {
        }
        public GroupResponse(bool success, Models.Group data) : base(success, null, new Group(data))
        {
        }
        public GroupResponse(bool success, string? message) : base(success, message, null)
        {
        }

        public GroupResponse(bool success, ICollection<Group> data) : base(success, null, data)
        {
        }

        public class Group
        {
            public int Id { get; set; }
            public int SchoolId { get; set; }
            public UserResponse.ShortUser Teacher { get; set; }
            public bool IsSubGroup { get; set; }
            public bool Active { get; set; }
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

            public Group(Models.Group group)
            {
                Id = group.Id;
                SchoolId = group.SchoolId;
                Teacher = new UserResponse.ShortUser(group.Teacher);
                IsSubGroup = group.IsSubGroup;
                Active = group.Active;
                Name = group.Name;
                CreatedAt = group.CreatedAt;
                UpdatedAt = group.UpdatedAt;
            }
        }
    }
}
