using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();
        public Task<Student?> GetStudentByIdAsync(int Id);

        public Task<Student> CreateStudentAsync(Student student);
        public Task<bool> StudentExistsAsync(int Id);

        public Task<Student> UpdateStudentAsync(Student student, Student newStudent);

        public void DeleteStudent(Student student);
    }
}
