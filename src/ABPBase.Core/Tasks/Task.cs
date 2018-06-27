using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace ABPBase.Tasks
{
   /// <summary>
   /// 添加的一个简单实体类
   /// </summary>
   [Table("AppTasks")]
    public class Task : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public TaskState State { get; set; }

        public Task()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
        }

        public Task(string title, string description = null,Guid? assginAssignedPersonId=null) : this()
        {
            Title = title;
            Description = description;
            AssignedPersonId = assginAssignedPersonId;
        }
        [ForeignKey(nameof(AssignedPersonId))] //外键标记给Person
        public Person AssignedPerson { get; set; } 
        public Guid? AssignedPersonId { get; set; } //外键
    }
    public enum TaskState : byte
    {
        Open = 0,
        Completed = 1
    }


}
