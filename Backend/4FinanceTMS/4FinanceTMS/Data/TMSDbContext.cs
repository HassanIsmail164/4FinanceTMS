using _4FinanceTMS.Models;
using Microsoft.EntityFrameworkCore;

namespace _4FinanceTMS.Data
{
    public class TMSDbContext : DbContext
    {
        public TMSDbContext(DbContextOptions<TMSDbContext> options) : base(options)
        {

        }

        // if tbale dosen't exist it creates it
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

}
