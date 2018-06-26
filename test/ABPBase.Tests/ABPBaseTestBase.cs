using System;
using System.Threading.Tasks;
using Abp.TestBase;
using ABPBase.EntityFrameworkCore;
using ABPBase.Tests.TestDatas;

namespace ABPBase.Tests
{
    public class ABPBaseTestBase : AbpIntegratedTestBase<ABPBaseTestModule>
    {
        public ABPBaseTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<ABPBaseDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ABPBaseDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<ABPBaseDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ABPBaseDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<ABPBaseDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<ABPBaseDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<ABPBaseDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ABPBaseDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
