using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ABPBase.EntityFrameworkCore
{
    [DependsOn(
        typeof(ABPBaseCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class ABPBaseEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBaseEntityFrameworkCoreModule).GetAssembly());
        }
    }
}