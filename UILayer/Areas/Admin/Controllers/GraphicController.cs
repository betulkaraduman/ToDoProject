using BusinessLayer.Interfaces;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.StringInfo;

namespace UILayer.Areas.Admin.Controllers
{
    [Authorize(Roles = AreaInfos.Admin)]
    [Area(RoleInfos.Admin)]
    public class GraphicController : Controller
    {
        IAppUserService _userService;

        public GraphicController(IAppUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {

            TempData["Active"] = TempDataInfo.Graphic;
            return View();
        }


        public IActionResult MostFinished()
        {
            var result = JsonConvert.SerializeObject(_userService.MostWorkFinishedStaff());
            return Json(result);
        }
        public IActionResult MostNotFinished()
        {
            var result = JsonConvert.SerializeObject(_userService.MostWorkNotFinishedStaff());
            return Json(result);
        }
    }
}
