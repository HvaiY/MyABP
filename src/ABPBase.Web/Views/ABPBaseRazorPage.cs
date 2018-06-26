using Abp.AspNetCore.Mvc.Views;

namespace ABPBase.Web.Views
{
    public abstract class ABPBaseRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected ABPBaseRazorPage()
        {
            LocalizationSourceName = ABPBaseConsts.LocalizationSourceName;
        }
    }
}
