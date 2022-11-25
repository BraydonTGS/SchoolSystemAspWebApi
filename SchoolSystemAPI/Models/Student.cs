using System.ComponentModel.DataAnnotations;

namespace SchoolSystemAPI.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string StudentEmail { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = null!; 
        public IEnumerable<Subject> Subjects { get; set; } = Enumerable.Empty<Subject>(); 


    }
}
