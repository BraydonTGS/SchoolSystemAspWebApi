using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.DTO
{
    public class StudentDTO
    {

        public int StudentId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = null!;

        public StudentDTO()
        {

        }

        public StudentDTO(int studentId, string firstName, string lastName, string email, string contactNumber)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
        }



    }
}
