using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ISchoolRepository
    {
        public IEnumerable<School> GetAllSchools();
        public School? GetSchoolById(int Id);

        public School CreateSchool(string Name, string address, string city, string state, string zipcode);
        public bool SchoolExists(int Id); 
    }
}
