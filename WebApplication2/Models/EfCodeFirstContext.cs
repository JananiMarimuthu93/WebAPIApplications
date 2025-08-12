using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class EfCodeFirstContext:DbContext
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
            
        }
    }
}

