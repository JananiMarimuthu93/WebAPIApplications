using WebApplication2.Models;

namespace CodeFirstApproach.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student?> UpdateStudent(int id, Student student);
        Task<Student?> DeleteStudent(int id);
    }
}
