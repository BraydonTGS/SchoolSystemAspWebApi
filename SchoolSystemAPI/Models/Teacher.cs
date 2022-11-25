using System.ComponentModel.DataAnnotations;

namespace SchoolSystemAPI.Models
{
    public class Teacher
    {
        [Key]
        [Required]
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!; 
        public string Email { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public IEnumerable<Subject> Subjects { get; set; } = Enumerable.Empty<Subject>();

    }
}
