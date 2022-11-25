using System.ComponentModel.DataAnnotations;

namespace SchoolSystemAPI.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!; 
       public ClassRoom ClassRoom { get; set; } 

    }
}
