using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class EfCodeFirstContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public EfCodeFirstContext()
        {

        }

        // Called during execution
        public EfCodeFirstContext(DbContextOptions<EfCodeFirstContext> options) : base(options)
        {

        }
        // Uncomment and configure this method if you want to setup your DB connection here
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KDJ-LAPTOP\\SQLEXPRESS;database=WebAPI;Integrated Security=True;TrustServerCertificate=True;");
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Standard>(entity =>
            //{
            //     entity.HasKey(s => s.StandardId);// Primary Key

            //     entity.Property(s => s.StandardName)
            //           .IsRequired()
            //           .HasMaxLength(100);

            //     entity.Property(s => s.Description)
            //           .HasMaxLength(250);

            // Seed Standards
            modelBuilder.Entity<Student>(entity
                =>entity.HasOne(s => s.Standard).WithMany(s => s.Students).HasForeignKey(s => s.StandardId));
            modelBuilder.Entity<Standard>().HasData(
            new Standard
            {
                StandardId = 1,
                StandardName = "Grade 10",
                Description = "Tenth grade students"
            },
            new Standard
            {
                StandardId = 2,
                StandardName = "Grade 11",
                Description = "Eleventh grade students"
            });
            //});


            // Configure Student entity
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.HasKey(st => st.StudentId); // Primary Key

            //    entity.Property(st => st.FirstName)
            //          .IsRequired()
            //          .HasMaxLength(50);

            //    entity.Property(st => st.LastName)
            //          .IsRequired()
            //          .HasMaxLength(50);

            //    // Relationship: One Standard has many Students
            //    entity.HasOne(st => st.Standard)
            //          .WithMany(s => s.Students)
            //          .HasForeignKey(st => st.StandardId)
            //          .OnDelete(DeleteBehavior.Cascade);

                // Seed Students
                modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Janani",
                    LastName = "Marimuthu",
                    StandardId = 1 // Assuming foreign key exists
                },
                new Student
                {
                    StudentId = 2,
                    FirstName = "Deepika",
                    LastName = "Marimuthu",
                    StandardId = 2
                });
                //});
            }
    }
}
            

 

  