using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ISchoolRepository
    {
        public Task<IEnumerable<School>> GetAllSchools();
        public Task<School?> GetSchoolById(int Id);

        public Task<School> CreateSchool(School school); 
        public bool SchoolExists(int Id);

        public School UpdateSchool(School school, School newSchool); 

        public void DeleteSchool(School school);
    }
}
