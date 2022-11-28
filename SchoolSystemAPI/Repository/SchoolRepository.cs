using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTO;
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

        // Get All Schools //
        public async Task< IEnumerable<School>> GetAllSchools()
        {
            var schools = await _context.Schools.ToListAsync();
            return schools; 
        }

        // Get School by Id //
        public async Task<School?> GetSchoolById(int Id)
       { 
            var school = await _context.Schools.Where(s => s.SchoolId == Id).FirstOrDefaultAsync();
            return school; 
        }

        // Update School //
        public async Task<School> UpdateSchool(School school, School updateSchool)
        {
      
            school.SchoolName = updateSchool.SchoolName;
            school.Address = updateSchool.Address;
            school.City= updateSchool.City;
            school.State= updateSchool.State;
            school.PostalCode= updateSchool.PostalCode;

            _context.Schools.Attach(school);
           await _context.SaveChangesAsync();
            return school; 
        }

        // Create New School //
        public School CreateSchool(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
            return school;
        }

        // Delete School by Id //
        public void DeleteSchool(School school)
        {
            _context.Remove(school);
            _context.SaveChanges();
        }

        // Does School Exist //
        public bool SchoolExists(int Id)
        {
            return _context.Schools.Any(s => s.SchoolId == Id);
        }

    }
}
