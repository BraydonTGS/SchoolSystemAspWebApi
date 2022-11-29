using SchoolSystemAPI.Data;
using SchoolSystemAPI.Interfaces;

namespace SchoolSystemAPI.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
