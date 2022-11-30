using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        [JsonIgnore]
        public ClassRoom ClassRoom { get; set; } = null!; 

    }
}
