using Microsoft.EntityFrameworkCore;

namespace ABPBase.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ABPBaseDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for ABPBaseDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
