using Abp.EntityFrameworkCore;
using ABPBase.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ABPBase.EntityFrameworkCore
{
    public class ABPBaseDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Person> People { get; set; }
        public ABPBaseDbContext(DbContextOptions<ABPBaseDbContext> options) 
            : base(options)
        {

        }

       
    }
}
