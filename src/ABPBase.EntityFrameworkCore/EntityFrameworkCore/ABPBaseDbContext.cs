using Abp.EntityFrameworkCore;
using ABPBase.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ABPBase.EntityFrameworkCore
{
    public class ABPBaseDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public ABPBaseDbContext(DbContextOptions<ABPBaseDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
