using ABPBase.Configuration;
using ABPBase.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ABPBase.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class ABPBaseDbContextFactory : IDesignTimeDbContextFactory<ABPBaseDbContext>
    {
        public ABPBaseDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ABPBaseDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(ABPBaseConsts.ConnectionStringName)
            );

            return new ABPBaseDbContext(builder.Options);
        }
    }
}