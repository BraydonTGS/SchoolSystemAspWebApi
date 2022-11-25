using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationDbContext _context;

        public SchoolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<School> GetAllSchools()
        {
            return _context.Schools.OrderBy(id => id).ToList();
        }

        public School GetSchoolById(int Id)
        {
            throw new NotImplementedException();
        }

        public School GetSchoolByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
