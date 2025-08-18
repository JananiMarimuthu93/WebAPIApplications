using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManyToManyApi.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;

        // Navigation property for the many-to-many relationship
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
