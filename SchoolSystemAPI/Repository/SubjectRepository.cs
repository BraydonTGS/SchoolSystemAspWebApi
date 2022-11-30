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

        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public void DeleteSubject(Subject subject)
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

        public async Task<Subject> UpdateSubjectAsync(Subject subject, Subject newSubject)
        {
            subject.SubjectId = newSubject.SubjectId;
            subject.SubjectName = newSubject.SubjectName;
            subject.ClassRoom = newSubject.ClassRoom;

            _context.Subjects.Attach(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
    }
}
