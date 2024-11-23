using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class appcomtext : IdentityDbContext<appuser>
    {
        public DbSet<labs> labs { get; set; }
        public DbSet<trainer> trainers  { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<instructor> instructors  { get; set; }

        public appcomtext() : base() { }
        public appcomtext(DbContextOptions<appcomtext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R30BCER\\MSSQLSERVER1;Initial Catalog=test-img;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
