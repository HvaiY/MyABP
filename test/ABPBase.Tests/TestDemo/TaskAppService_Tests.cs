﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Runtime.Validation;
using ABPBase.AppServices;
using ABPBase.Dtos;
using ABPBase.Tasks;
using Shouldly;
using Xunit;

namespace ABPBase.Tests
{
    public class TaskAppService_Tests:ABPBaseTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppService_Tests()
        {
            _taskAppService = Resolve<ITaskAppService>();
        }
        [Fact]
        public async System.Threading.Tasks.Task Should_Get_All_Tasks()
        {
            //Act
            var output = await _taskAppService.GetAll(new GetAllTasksInput());

            //Assert
            output.Items.Count.ShouldBe(2);
            output.Items.Count(t=>t.AssignedPersonName!=null).ShouldBe(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Filtered_Tasks()
        {
            //Act
            var output = await _taskAppService.GetAll(new GetAllTasksInput { State = TaskState.Open });

            //Assert
            output.Items.ShouldAllBe(t => t.State == TaskState.Open);
        }

        //创建测试
        [Fact]
        public async System.Threading.Tasks.Task Should_Create_New_Task_With_Title()
        {
            await _taskAppService.Create(new CreateTaskInput
            {
                Title = "Newly created task #1"
            });

            UsingDbContext(context =>
            {
                var task1 = context.Tasks.FirstOrDefault(t => t.Title == "Newly created task #1");
                task1.ShouldNotBeNull();
            });
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Create_New_Task_With_Title_And_Assigned_Person()
        {
            var neo = UsingDbContext(context => context.People.Single(p => p.Name == "Neo"));

            await _taskAppService.Create(new CreateTaskInput
            {
                Title = "Newly created task #1",
                AssignedPersonId = neo.Id
            });

            UsingDbContext(context =>
            {
                var task1 = context.Tasks.FirstOrDefault(t => t.Title == "Newly created task #1");
                task1.ShouldNotBeNull();
                task1.AssignedPersonId.ShouldBe(neo.Id);
            });
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Not_Create_New_Task_Without_Title()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _taskAppService.Create(new CreateTaskInput
                {
                    Title = null
                });
            });
        }
    }
}
