using Microsoft.EntityFrameworkCore;
using Student_edu.Core.Models;

namespace Student_edu.Infrastructure.DBConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}