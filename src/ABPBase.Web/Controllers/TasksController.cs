using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABPBase.AppServices;
using ABPBase.Dtos;
using ABPBase.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABPBase.Web.Controllers
{
    public class TasksController : ABPBaseControllerBase//
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }
        //Install-Package BuildBundlerMinifier -Version 2.8.391 获取该插件可以压缩js //自动压缩js 生成**.min.js
        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items){ SelectedTaskState = input.State };
            return View(model);
        }
    }
}