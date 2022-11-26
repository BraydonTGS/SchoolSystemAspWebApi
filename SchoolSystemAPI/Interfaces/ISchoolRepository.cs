using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ISchoolRepository
    {
        public IEnumerable<School> GetAllSchools();
        public School? GetSchoolById(int Id);

        public School CreateSchool(SchoolDTO school); 
        public bool SchoolExists(int Id);

        public School UpdateSchool(School school, SchoolDTO schoolDTO); 
    }
}
