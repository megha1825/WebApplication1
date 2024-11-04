using Microsoft.EntityFrameworkCore;
using WebApplication1.Database.Entity;
using WebApplication1.Pages.models;

namespace WebApplication1.Database.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Signup> Signups{ get; set; }
        public DbSet<login> logins { get; set; }

        public DbSet<product> products { get; set; }

    }
}
