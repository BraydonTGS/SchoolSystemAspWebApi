using SchoolSystemAPI.Data;
using SchoolSystemAPI.Interfaces;

namespace SchoolSystemAPI.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
