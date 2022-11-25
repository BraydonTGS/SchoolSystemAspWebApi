using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        // Create New School //
        public School CreateSchool(string Name, string Address, string City, string State, string Zipcode)
        {
            School newSchool = new School()
            {
                SchoolName = Name,
                Address = Address,
                City = City,
                State = State,
                PostalCode = Zipcode
            }; 
            _context.Schools.Add(newSchool);
            _context.SaveChanges();
            return newSchool;
        }

        public void CreateSchoolTest(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
           
        }

        public bool SchoolExists(int Id)
        {
            return _context.Schools.Any(s => s.SchoolId == Id);
        }

    }
}
