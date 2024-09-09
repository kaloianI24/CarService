using Microsoft.EntityFrameworkCore;

namespace CarService.Data.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AutoParts> AutoParts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
    }
}
