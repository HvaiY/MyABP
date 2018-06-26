using System;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ABPBase.Tasks;

namespace ABPBase.Dtos
{
    public class TaskListDto:Entity,IHasCreationTime
    {
        [AutoMapFrom(typeof(Task))] //自动映射实体类（使用的是AutoMapper）
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }
    }
}
