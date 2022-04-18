using ISRPO.Fourth.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ISRPO.Fourth.Infrastructure.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.Migrate();
            Database.EnsureCreated();
        }
    }
    
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Instruments");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}