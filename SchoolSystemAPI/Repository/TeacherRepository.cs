using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public void DeleteTeacher(Teacher teacher)
        {
            _context.Remove(teacher);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            var teacher = await _context.Teachers.ToListAsync();
            return teacher;
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int Id)
        {
            return await _context.Teachers.Where(t => t.TeacherId == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> TeacherExistsAsync(int Id)
        {
            return await _context.Teachers.AnyAsync(t => t.TeacherId == Id);
        }


        public async Task<Teacher> UpdateTeacherAsync(Teacher teacher, Teacher newTeacher)
        {

            teacher.FirstName= newTeacher.FirstName;
            teacher.LastName = newTeacher.LastName;
            teacher.ContactNumber = newTeacher.ContactNumber;
            teacher.Email= newTeacher.Email;

            _context.Teachers.Attach(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}

    
    

