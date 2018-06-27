using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using ABPBase.Dtos;
using Microsoft.EntityFrameworkCore;
using Task = ABPBase.Tasks.Task;

namespace ABPBase.AppServices
{
    public class TaskAppService : ABPBaseAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _tasRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _tasRepository = taskRepository;
        }
        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _tasRepository
                .GetAll()
                .Include(t=>t.AssignedPerson)
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToDynamicListAsync();//案例中是 ToListAsync()这里找不到。。

            return new ListResultDto<TaskListDto>(ObjectMapper.Map<List<TaskListDto>>(tasks));
        }

        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await _tasRepository.InsertAsync(task);
        }
    }
}
