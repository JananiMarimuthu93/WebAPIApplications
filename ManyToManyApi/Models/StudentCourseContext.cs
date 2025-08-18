using Microsoft.EntityFrameworkCore;

namespace ManyToManyApi.Models
{
    public class StudentCourseContext : DbContext
    {
        public DbSet<EnrolledStudent> EnrolledStudents { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;

        public StudentCourseContext(DbContextOptions<StudentCourseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite key for StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Configure relationships
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.EnrolledStudent)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            modelBuilder.Entity<EnrolledStudent>().HasData(
                new EnrolledStudent { StudentId = 1, StudentName = "Janani M" },
                new EnrolledStudent { StudentId = 2, StudentName = "Deepika M" },
                new EnrolledStudent { StudentId = 3, StudentName = "Kesavi M" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 101, Title = "Mathematics" },
                new Course { CourseId = 102, Title = "Physics" },
                new Course { CourseId = 103, Title = "Computer Science" }
            );

            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { StudentId = 1, CourseId = 101 },
                new StudentCourse { StudentId = 1, CourseId = 102 },
                new StudentCourse { StudentId = 2, CourseId = 103 },
                new StudentCourse { StudentId = 3, CourseId = 101 }
            );
        }
    }
}
