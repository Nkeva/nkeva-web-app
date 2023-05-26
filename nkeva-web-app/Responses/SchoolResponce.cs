using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Responses
{
    public class SchoolResponce : BaseResponse
    {
        public SchoolResponce(bool success, string? message, Model? data) : base(success, message, data)
        {
        }

        public SchoolResponce(bool success, string? message) : base(success, message, null)
        {
        }

        public SchoolResponce(bool success, Model? data) : base(success, null, data)
        {
        }

        public SchoolResponce(Model? data) : base(true, null, data)
        {
        }

        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string ZipCode { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

            public Model(Models.School school)
            {
                Id = school.Id;
                Name = school.Name;
                Address = school.Address;
                City = school.City;
                Country = school.Country;
                ZipCode = school.ZipCode;
                Phone = school.Phone;
                Email = school.Email;
                Active = school.Active;
                CreatedAt = school.CreatedAt;
                UpdatedAt = school.UpdatedAt;
            }

            public static implicit operator Model(Models.School school)
            {
                return new Model(school);
            }

        }
    }
}
