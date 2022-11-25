using System.ComponentModel.DataAnnotations;

namespace SchoolSystemAPI.Models
{
    public class School
    {
        [Key]
        [Required]
        public int SchoolId { get; set; }
        public string SchoolName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!; 

        public IEnumerable<Teacher> Teachers { get; set; } = Enumerable.Empty<Teacher>(); 
        public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>(); 
    }
}
