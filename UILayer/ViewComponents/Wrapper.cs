using AutoMapper;
using BusinessLayer.Interfaces;
using DTOService.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Areas.Admin.Models;

namespace UILayer.ViewComponents
{
    public class Wrapper:ViewComponent
    {
        UserManager<AppUser> _userManager;
        INotificationService _notificationService;
        IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _notificationService = notificationService;
        }
        public IViewComponentResult Invoke()
        {
        var identityUser= _userManager.FindByNameAsync(User.Identity.Name).Result;
            var user = _mapper.Map<AppUserListDto>(identityUser);
            //AppUserListViewModel model = new AppUserListViewModel();
            //model.Id = user.Id;
            //model.Name = user.Name;
            //model.Surname = user.Surname;
            //model.Email = user.Email;
            //model.Username = user.UserName;
            //model.Picture = user.Picture;
           var notification=  _notificationService.GetNotRead(user.Id).Count;
            ViewBag.notification = notification;

            var roles = _userManager.GetRolesAsync(identityUser).Result;
            if (roles.Contains("Admin"))
            {
                return View(user);

            }
            return View("Member", user);




        }
    }
}
