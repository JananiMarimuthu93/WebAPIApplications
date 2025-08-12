using CodeFirstApproach.Interface;
using CodeFirstApproach.Repository;
using CodeFirstApproach.Service;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _service.GetAllStudents();
        }
        [HttpGet("id")]
        public async Task<Student> GetStudentById(int id)
        {
            return await _service.GetStudentById(id);
        }
    }
}
