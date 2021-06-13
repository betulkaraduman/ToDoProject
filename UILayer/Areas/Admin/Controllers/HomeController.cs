using AutoMapper;
using BusinessLayer.Interfaces;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.BaseControllers;
using UILayer.StringInfo;

namespace UILayer.Areas.Admin.Controllers
{
    [Authorize(Roles = AreaInfos.Admin)]
    [Area(RoleInfos.Admin)]
    public class HomeController : BaseIdentityController
    {
        IReportService _reportService;
        IWorkService _workService;
        INotificationService _notificationService;
        IMapper _mapper;
        public HomeController(UserManager<AppUser> userManager, IWorkService workService, INotificationService notificationService, IReportService reportService, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
            _reportService = reportService;
            _notificationService = notificationService;
            _workService = workService;

        }
        public async Task<IActionResult> Index()
        {

            TempData["Active"] = TempDataInfo.Home;
            var user = await LoginUser();
            ViewBag.NotAssign=_workService.GetNotAssignWorkCountByUserId();
            ViewBag.AllReport=_reportService.GetReportCount();
            ViewBag.Finished=_workService.GetFinishWorkCountByUserId();
            ViewBag.NotReadNotification = _notificationService.GetNotificationCountByUserId(user.Id);
            return View();
        }
        public IActionResult Register()
        {
            return View();

        }
    }
}
