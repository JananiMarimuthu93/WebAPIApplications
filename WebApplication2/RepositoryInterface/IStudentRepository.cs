using WebApplication2.Models;

namespace CodeFirstApproach.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
    }
}
