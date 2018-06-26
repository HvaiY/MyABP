using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPBase.Web.Startup;
namespace ABPBase.Web.Tests
{
    [DependsOn(
        typeof(ABPBaseWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class ABPBaseWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBaseWebTestModule).GetAssembly());
        }
    }
}