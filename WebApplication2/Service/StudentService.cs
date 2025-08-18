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

        // Get all students (with Standard navigation property)
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students
                                 .Include(s => s.Standard)
                                 .ToListAsync();
        }

        // Get student by Id
        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Students
                                 .Include(s => s.Standard)
                                 .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        // Add new student
        public async Task<Student> AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // Update existing student
        public async Task<Student?> UpdateStudent(int id, Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.StandardId = student.StandardId;

            await _context.SaveChangesAsync();
            return existingStudent;
        }

        // Delete student
        public async Task<Student?> DeleteStudent(int id)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            if (existingStudent == null)
            {
                return null;
            }

            _context.Students.Remove(existingStudent);
            await _context.SaveChangesAsync();
            return existingStudent;
        }
    }
}
