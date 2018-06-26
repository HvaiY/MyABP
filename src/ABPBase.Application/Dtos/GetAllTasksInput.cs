using System;
using System.Collections.Generic;
using System.Text;
using ABPBase.Tasks;

namespace ABPBase.Dtos
{
   public class GetAllTasksInput
    {
        public TaskState? State { get; set; }
    }
}
