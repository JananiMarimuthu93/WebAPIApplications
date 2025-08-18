using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManyToManyApi.Models
{
    public class EnrolledStudent
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;

        // Navigation property for the many-to-many relationship
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
