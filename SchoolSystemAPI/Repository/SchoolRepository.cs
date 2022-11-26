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
        public IEnumerable<School> GetAllSchools()
        {
            return _context.Schools.OrderBy(id => id).ToList();
        }

        // Get School by Id //
        public School? GetSchoolById(int Id)
        {
       
            var school = _context.Schools.Where(s => s.SchoolId == Id).FirstOrDefault();
            return school; 
        }

        // Update School //
        public School UpdateSchool(School school, SchoolDTO schoolDTO)
        {
      
            school.SchoolName = schoolDTO.SchoolName;
            school.Address = schoolDTO.Address;
            school.City= schoolDTO.City;
            school.State= schoolDTO.State;
            school.PostalCode= schoolDTO.PostalCode;

            _context.Schools.Attach(school);
            _context.SaveChanges();
            return school; 
        }

        // Create New School //
        public School CreateSchool(SchoolDTO dto)
        {
            var newSchool = new School()
            {
                SchoolName = dto.SchoolName,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode,
            }; 
            _context.Schools.Add(newSchool);
            _context.SaveChanges();

            return newSchool;
        }

        // Does School Exist //
        public bool SchoolExists(int Id)
        {
            return _context.Schools.Any(s => s.SchoolId == Id);
        }

    }
}
