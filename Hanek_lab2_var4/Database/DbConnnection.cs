using Microsoft.EntityFrameworkCore;


namespace Lab2
{
    
    public class DbConnection : DbContext
    {

        public DbConnection(DbContextOptions<DbConnection> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
    }
}
