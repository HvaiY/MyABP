using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPBase.Configuration;
using ABPBase.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ABPBase.Web.Startup
{
    [DependsOn(
        typeof(ABPBaseApplicationModule), 
        typeof(ABPBaseEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class ABPBaseWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ABPBaseWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(ABPBaseConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<ABPBaseNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ABPBaseApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBaseWebModule).GetAssembly());
        }
    }
}