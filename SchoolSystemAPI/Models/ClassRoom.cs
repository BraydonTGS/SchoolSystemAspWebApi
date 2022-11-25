using System.ComponentModel.DataAnnotations;

namespace SchoolSystemAPI.Models
{
    public class ClassRoom
    {
        [Key]
        [Required]
        public int ClassRoomId { get; set; }

    }
}
