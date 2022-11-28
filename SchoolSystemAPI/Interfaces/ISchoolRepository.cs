using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ISchoolRepository
    {
        public IEnumerable<School> GetAllSchools();
        public School? GetSchoolById(int Id);

        public School CreateSchool(School school); 
        public bool SchoolExists(int Id);

        public School UpdateSchool(School school, School newSchool); 

        public void DeleteSchool(School school);
    }
}
