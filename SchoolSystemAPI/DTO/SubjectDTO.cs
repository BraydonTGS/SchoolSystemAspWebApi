﻿using SchoolSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystemAPI.DTO
{
    public class SubjectDTO
    {
   
        [Key]
        [Required]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public ClassRoom ClassRoom { get; set; } = null!;

        public SubjectDTO(int subjectId, string subjectName, ClassRoom classRoom)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            ClassRoom = classRoom;
        }
    }
}