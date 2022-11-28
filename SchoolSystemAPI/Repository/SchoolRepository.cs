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
           return await _context.Schools.Where(s => s.SchoolId == Id).FirstOrDefaultAsync();
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
        public async Task<School> CreateSchool(School school)
        {
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        // Delete School by Id //
        public void DeleteSchool(School school)
        {
            _context.Remove(school);
            _context.SaveChanges();
        }

        // Does School Exist //
        public async Task<bool> SchoolExists(int Id)
        {
            return await _context.Schools.AnyAsync(s => s.SchoolId == Id);
        }

    }
}
