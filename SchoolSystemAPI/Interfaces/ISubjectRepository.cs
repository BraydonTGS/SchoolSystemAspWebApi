using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ISubjectRepository
    {
        public Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        public Task<Subject?> GetSubjectByIdAsync(int Id);

        public Task<Subject> CreateSubjectAsync(Subject subject);
        public Task<bool> SubjectExistsAsync(int Id);

        public Task<Subject> UpdateSubjectAsync(Subject subject, Subject newSubject);

        public void DeleteSubject(Subject subject);
    }
}
