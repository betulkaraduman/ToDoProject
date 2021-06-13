using AutoMapper;
using BusinessLayer.Interfaces;
using DTOService.DTOs.ReportDTOs;
using DTOService.DTOs.WorkDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Areas.Admin.Models;
using UILayer.BaseControllers;
using UILayer.StringInfo;

namespace UILayer.Areas.Member.Controllers
{
    [Authorize(Roles = AreaInfos.Member)]
    [Area(RoleInfos.Member)]
    public class AssigmentController : BaseIdentityController
    {
        UserManager<AppUser> _userManager;
        IWorkService _workService;
        INotificationService _notificationService;
        IReportService _reportService;
        IMapper _mapper;
        public AssigmentController(IWorkService workService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
            _notificationService = notificationService;
            _reportService = reportService;
            _userManager = userManager;
            _workService = workService;
        }
        public async Task<IActionResult> Index()
        {

            TempData["Active"] = TempDataInfo.Assigment;
            var user = await LoginUser();
            //var work = _mapper.Map<WorkListAllDto>(_workService.AllData(I => I.AppUserId == user.Id && !I.State));
            //List<WorkListAllViewModel> models = new List<WorkListAllViewModel>();
            //foreach (var item in work)
            //{
            //    WorkListAllViewModel model = new WorkListAllViewModel();
            //    model.Name = item.Name;
            //    model.Description = item.Description;
            //    model.Id = item.Id;
            //    model.urgency = item.urgency;
            //    model.reports = item.reports;
            //    model.CreateTime = item.CreateTime;
            //    model.appUser = item.appUser;
            //    models.Add(model);
            //}


            return View(_mapper.Map<List<WorkListAllDto>>(_workService.AllData(I => I.AppUserId == user.Id && !I.State)));
        }

        public IActionResult WriteReport(int Id)
        {
            TempData["Active"] = TempDataInfo.Assigment;
            ReportAddDto model = new ReportAddDto();
            model.WorkId = Id;
            model.work = _workService.GetByUrgencyId(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriteReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {

                var report = new Report();
                report.Definition = model.Definition;
                report.Detail = model.Detail;
                report.WorkId = model.WorkId;
                _reportService.Save(report);
                var AdminUsers = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await LoginUser();
                foreach (var user in AdminUsers)
                {
                    _notificationService.Save(new Notification
                    {
                        Description=$"{activeUser.Name} {activeUser.Surname} wrote a new report",
                        AppUserId=user.Id,
                        State=false
                    });
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int Id)
        {
            TempData["Active"] = TempDataInfo.Assigment;
            var report = _reportService.GetWorkById(Id);
            ReportUpdateDto model = new ReportUpdateDto();
            model.Definition = report.Definition;
            model.Detail = report.Detail;
            model.Id = report.Id;
            model.work = report.work;
            model.WorkId = report.WorkId;
            return View(model);
        }

        [HttpPost]

        public IActionResult UpdateReport(ReportUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var oldReport = _reportService.GetEntityById(model.Id);
                oldReport.Definition = model.Definition;
                oldReport.Detail = model.Detail;

                _reportService.Update(oldReport);
                return RedirectToAction("Index");
            }
            return View();

        }


        public async Task<IActionResult> FinishWork(int id)
        {
                        TempData["Active"] = TempDataInfo.Assigment;
            var updatedWork = _workService.GetEntityById(id);
            updatedWork.State = true;
            _workService.Update(updatedWork);
            var AdminUsers = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await LoginUser();
            foreach (var user in AdminUsers)
            {
                _notificationService.Save(new Notification
                {
                    Description = $"{activeUser.Name} {activeUser.Surname} has finished its task",
                    AppUserId = user.Id,
                    State = false
                });
            }
            return Json(null);
        }
    }
}
