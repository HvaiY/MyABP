using Abp.Application.Services;

namespace ABPBase
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ABPBaseAppServiceBase : ApplicationService
    {
        protected ABPBaseAppServiceBase()
        {
            LocalizationSourceName = ABPBaseConsts.LocalizationSourceName;
        }
    }
}