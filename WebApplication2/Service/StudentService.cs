using CodeFirstApproach.Interface;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace CodeFirstApproach.Service
{
    public class StudentService : IStudentRepository
    {
        private readonly EfCodeFirstContext _context;

        public StudentService(EfCodeFirstContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.Include(s => s.Standard).ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
        }
    }
}
