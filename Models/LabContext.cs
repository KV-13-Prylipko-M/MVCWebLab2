using Microsoft.EntityFrameworkCore;

namespace MVCWebLab2.Models {
    public class LabContext : DbContext {
        public DbSet<User> Users { get; set; }
        public LabContext(DbContextOptions<LabContext> options) : base(options) { }
        public LabContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=WebLab2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
