using Lab4;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {   
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
