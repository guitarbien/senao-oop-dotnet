using Microsoft.EntityFrameworkCore;

namespace Service.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Backup> Backups { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}