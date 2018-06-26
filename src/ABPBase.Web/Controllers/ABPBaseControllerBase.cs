using Abp.AspNetCore.Mvc.Controllers;

namespace ABPBase.Web.Controllers
{
    public abstract class ABPBaseControllerBase: AbpController
    {
        protected ABPBaseControllerBase()
        {
            LocalizationSourceName = ABPBaseConsts.LocalizationSourceName;
        }
    }
}