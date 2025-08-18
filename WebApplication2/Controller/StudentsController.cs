using CodeFirstApproach.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace CodeFirstApproach.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _service;

        public StudentsController(IStudentRepository service)
        {
            _service = service;
        }

        // ✅ GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _service.GetAllStudents();
            return Ok(students);
        }

        // ✅ GET: api/students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _service.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }

        // ✅ POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var createdStudent = await _service.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
        }

        // ✅ PUT: api/students/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            var updatedStudent = await _service.UpdateStudent(id, student);
            if (updatedStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(updatedStudent);
        }

        // ✅ DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var deletedStudent = await _service.DeleteStudent(id);
            if (deletedStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(deletedStudent);
        }
    }
}
