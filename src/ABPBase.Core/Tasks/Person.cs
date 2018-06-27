using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace ABPBase.Tasks
{
    /// <summary>
    /// 该类继承了AuditedEntity<Guid> 那么现在该类具备了 主键ID字段 使用时值为Guid生成
    /// 具有CreationTime，CreaterUserId，LastModificationTime和LastModifierUserId属性
    /// </summary>
    [Table("AppPersons")]
    public class Person:AuditedEntity<Guid>
    {
        public const int MaxNameLength = 32; //限定名字长度的常量
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public Person()
        {
        }

        public Person(string name)
        {
            Name = name;
        }
    }
}
