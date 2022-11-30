using SchoolSystemAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.DTO
{
    public class TeacherDTO
    {

        [Key]
        [Required]
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        [JsonIgnore]
        public IEnumerable<Subject> Subjects { get; set; } = Enumerable.Empty<Subject>();

        public TeacherDTO()
        {

        }
        public TeacherDTO(int teacherId, string firstName, string lastName, string contactNumber, string email)
        {
            TeacherId = teacherId;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Email = email;
        }
    }
}
