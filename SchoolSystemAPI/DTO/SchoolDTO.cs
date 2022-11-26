using SchoolSystemAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.DTO
{
    public class SchoolDTO
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int SchoolId { get; set; }
        [Required]
        public string SchoolName { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string State { get; set; } = null!;
        [Required]
        public string PostalCode { get; set; } = null!;

        [JsonIgnore]
        public IEnumerable<Teacher> Teachers { get; set; } = Enumerable.Empty<Teacher>();
        [JsonIgnore]
        public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();
    }
}
