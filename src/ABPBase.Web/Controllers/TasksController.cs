using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ABPBase.AppServices;
using ABPBase.Dtos;
using ABPBase.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABPBase.Web.Controllers
{
    public class TasksController : ABPBaseControllerBase//
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ILookupAppService _lookupAppService;

        public TasksController(ITaskAppService taskAppService, ILookupAppService lookupAppService)
        {
            _taskAppService = taskAppService;
            _lookupAppService = lookupAppService;
        }
        //Install-Package BuildBundlerMinifier -Version 2.8.391 获取该插件可以压缩js //自动压缩js 生成**.min.js
        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items) { SelectedTaskState = input.State };
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var peopleSelectListItems = (await _lookupAppService.GetPeopleComboboxItems()).Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            return View(new CreateTaskViewModel(peopleSelectListItems));
        }
    }
}