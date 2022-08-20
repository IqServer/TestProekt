using System.Reflection;
using Microsoft.EntityFrameworkCore;
using models;

namespace Rt.DbLayer;
public class DataContext:DbContext
{
 public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }



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
