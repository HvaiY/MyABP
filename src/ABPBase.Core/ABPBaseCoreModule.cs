using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPBase.Localization;

namespace ABPBase
{
    public class ABPBaseCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            ABPBaseLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBaseCoreModule).GetAssembly());
        }
    }
}