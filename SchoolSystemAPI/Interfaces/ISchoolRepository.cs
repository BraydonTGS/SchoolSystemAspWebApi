using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ISchoolRepository
    {
        public Task<IEnumerable<School>> GetAllSchoolsAsync();
        public Task<School?> GetSchoolByIdAsync(int Id);

        public Task<School> CreateSchoolAsync(School school); 
        public Task<bool> SchoolExistsAsync(int Id);

        public Task<School> UpdateSchoolAsync(School school, School newSchool); 

        public void DeleteSchool(School school);
    }
}
