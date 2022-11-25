using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        DbSet<ClassRoom> ClassRooms { get; set; }
        DbSet<School> Schools { get; set; } 
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Teacher> Teachers { get; set; }


     
    }
}
