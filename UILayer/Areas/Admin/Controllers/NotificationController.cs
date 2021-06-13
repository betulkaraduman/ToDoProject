using AutoMapper;
using BusinessLayer.Interfaces;
using DTOService.DTOs.NotificationDTOs;
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

namespace UILayer.Areas.Admin.Controllers
{
    [Authorize(Roles = AreaInfos.Admin)]
    [Area(RoleInfos.Admin)]
    public class NotificationController : BaseIdentityController
    {
        INotificationService _notificationService;
        IMapper _mapper;
        public NotificationController(UserManager<AppUser> userManager, INotificationService notificationService,IMapper mapper):base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Notification;
            var user = await LoginUser();

           //var notification=_notificationService.GetNotRead(user.Id);
           //List<NotificationListViewModel> models = new List<NotificationListViewModel>();
           // foreach (var item in notification)
           // {
           //     NotificationListViewModel model = new NotificationListViewModel();
           //     model.Id = item.Id;
           //     model.Description = item.Description;
           //     models.Add(model);
           // }

            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetNotRead(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var updatedNotification = _notificationService.GetEntityById(id);
            updatedNotification.State = true;
            _notificationService.Update(updatedNotification);
            return RedirectToAction("Index");
        }
    }
}
