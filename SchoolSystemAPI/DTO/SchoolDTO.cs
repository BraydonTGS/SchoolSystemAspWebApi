using SchoolSystemAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.DTO
{
    public class SchoolDTO
    {
        public SchoolDTO()
        {
        }

        public SchoolDTO(int schoolId, string schoolName, string address, string city, string state, string postalCode)
        {
            SchoolId = schoolId;
            SchoolName = schoolName;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!; 

        [JsonIgnore]
        public IEnumerable<Teacher> Teachers { get; set; } = Enumerable.Empty<Teacher>();
        [JsonIgnore]
        public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();
    }
}
