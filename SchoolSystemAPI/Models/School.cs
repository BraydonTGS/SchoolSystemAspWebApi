using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.Models
{
    public class School
    {
        [Key]
        [Required]
        [JsonIgnore]
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
