using Microsoft.EntityFrameworkCore;

namespace SchoolSystemAPI.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }


     
    }
}
