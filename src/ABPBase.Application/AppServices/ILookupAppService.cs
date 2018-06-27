using Abp.Application.Services;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace ABPBase.AppServices
{
    public interface ILookupAppService:IApplicationService
    {
        Task<ListResultDto<ComboboxItemDto>> GetPeopleComboboxItems();
    }
}