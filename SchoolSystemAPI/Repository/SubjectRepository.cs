using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Subject> CreateSubjectAsync(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Subject subject)
        {
            _context.Remove(subject);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject?> GetSubjectByIdAsync(int Id)
        {
            return await _context.Subjects.Where(s => s.SubjectId == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> SubjectExistsAsync(int Id)
        {
            return await _context.Subjects.AnyAsync(s => s.SubjectId == Id);
        }

        public Task<Subject> UpdateSubjectAsync(Subject subject, Subject newSubject)
        {
            throw new NotImplementedException();
        }
    }
}
