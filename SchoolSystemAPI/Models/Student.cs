using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.Models
{
    public class Student
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string ContactNumber { get; set; } = null!;
        [JsonIgnore]
        public IEnumerable<Subject> Subjects { get; set; } = Enumerable.Empty<Subject>(); 


    }
}
