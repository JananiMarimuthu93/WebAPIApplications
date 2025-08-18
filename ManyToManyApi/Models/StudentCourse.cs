namespace ManyToManyApi.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public EnrolledStudent EnrolledStudent { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
