using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Rt.DbLayer;

namespace Rt.DbLayer;

internal class DiogelContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DataContext> dbContextOptionsBuilder =
            new();

        dbContextOptionsBuilder.UseNpgsql(@"localBuild");
        return new DataContext(dbContextOptionsBuilder.Options);
    }
}