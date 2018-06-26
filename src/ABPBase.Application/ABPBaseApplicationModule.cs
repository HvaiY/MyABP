using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ABPBase
{
    [DependsOn(
        typeof(ABPBaseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ABPBaseApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBaseApplicationModule).GetAssembly());
        }
    }
}