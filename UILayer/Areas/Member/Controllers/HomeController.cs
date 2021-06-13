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

namespace UILayer.Areas.Member.Controllers
{
    [Authorize(Roles = AreaInfos.Member)]
    [Area(RoleInfos.Member)]
    public class HomeController : BaseIdentityController
    {

        UserManager<AppUser> _userManager;
        IReportService _reportService;
        IWorkService _workService;
        INotificationService _notificationService;
        public HomeController(UserManager<AppUser> userManager, IReportService reportService, IWorkService workService, INotificationService notificationService):base(userManager)
        {
            _notificationService = notificationService;
            _workService = workService;
            _reportService = reportService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {


            TempData["Active"] = TempDataInfo.Home;
            var user = await LoginUser();
            ViewBag.ReportCount=_reportService.GetReportCountByUserId(user.Id);
            ViewBag.NotificationCount=_notificationService.GetNotificationCountByUserId(user.Id);
            ViewBag.WorkCount=_workService.GetWorkCountByUserId(user.Id);
            ViewBag.NotFinishedWorkCount=_workService.GetNotFinishedWorkCountByUserId(user.Id);
            return View();
        }
    }
}
