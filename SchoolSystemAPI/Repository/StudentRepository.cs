using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create A Student //
        public async Task<Student> CreateStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // Delete a Student //
        public void DeleteStudent(Student student)
        {
            _context.Remove(student);
            _context.SaveChanges();
        }

        // Get a List of Students //
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var student = await _context.Students.ToListAsync();
            return student;
        }
        
        // Get Student By Id //
        public async Task<Student?> GetStudentByIdAsync(int Id)
        {
            return await _context.Students.Where(s => s.StudentId == Id).FirstOrDefaultAsync();
        }

        // Does Student Exist //
        public async Task<bool> StudentExistsAsync(int Id)
        {
            return await _context.Students.AnyAsync(s => s.StudentId == Id);
        }

        // Update Student //
        public async Task<Student> UpdateStudentAsync(Student student, Student newStudent)
        {
            student.StudentId = newStudent.StudentId;
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            student.Email = newStudent.Email;
            student.ContactNumber = newStudent.ContactNumber;

            _context.Students.Attach(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
