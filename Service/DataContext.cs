using System.Reflection;
using Microsoft.EntityFrameworkCore;
using models;

namespace Rt.DbLayer;
public class DataContext:DbContext
{
 public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Student>? Students { get; set; }

        public void CreateBDNew()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
}
