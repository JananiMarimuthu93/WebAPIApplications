using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManyToManyApi.Models;

namespace ManyToManyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledStudentsController : ControllerBase
    {
        private readonly StudentCourseContext _context;

        public EnrolledStudentsController(StudentCourseContext context)
        {
            _context = context;
        }

        // GET: api/EnrolledStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrolledStudent>>> GetEnrolledStudents()
        {
            return await _context.EnrolledStudents.ToListAsync();
        }

        // GET: api/EnrolledStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrolledStudent>> GetEnrolledStudent(int id)
        {
            var enrolledStudent = await _context.EnrolledStudents.FindAsync(id);

            if (enrolledStudent == null)
            {
                return NotFound();
            }

            return enrolledStudent;
        }

        // PUT: api/EnrolledStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrolledStudent(int id, EnrolledStudent enrolledStudent)
        {
            if (id != enrolledStudent.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(enrolledStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrolledStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EnrolledStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnrolledStudent>> PostEnrolledStudent(EnrolledStudent enrolledStudent)
        {
            _context.EnrolledStudents.Add(enrolledStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrolledStudent", new { id = enrolledStudent.StudentId }, enrolledStudent);
        }

        // DELETE: api/EnrolledStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrolledStudent(int id)
        {
            var enrolledStudent = await _context.EnrolledStudents.FindAsync(id);
            if (enrolledStudent == null)
            {
                return NotFound();
            }

            _context.EnrolledStudents.Remove(enrolledStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnrolledStudentExists(int id)
        {
            return _context.EnrolledStudents.Any(e => e.StudentId == id);
        }
    }
}
