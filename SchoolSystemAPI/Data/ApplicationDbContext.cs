using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<School> Schools { get; set; } 
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


     
    }
}
