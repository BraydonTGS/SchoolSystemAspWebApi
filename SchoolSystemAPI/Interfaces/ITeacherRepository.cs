using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ITeacherRepository
    {
        public Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        public Task<Teacher?> GetTeacherByIdAsync(int Id);

        public Task<Teacher> CreateTeacherAsync(Teacher teacher);
        public Task<bool> TeacherExistsAsync(int Id);

        public Task<Teacher> UpdateTeacherAsync(Teacher teacher, Teacher newTeacher);

        public void DeleteTeacher(Teacher teacher);
    }
}
