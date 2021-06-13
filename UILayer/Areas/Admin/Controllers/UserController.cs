using AutoMapper;
using DTOService.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Areas.Admin.Models;
using UILayer.BaseControllers;
using UILayer.StringInfo;

namespace UILayer.Areas.Admin.Controllers
{
    [Authorize(Roles = AreaInfos.Admin)]
    [Area(RoleInfos.Admin)]
    public class UserController : BaseIdentityController
    {
        IMapper _mapper;
        public UserController(UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            TempData["Active"] = TempDataInfo.User;           
            AppUserListViewModel model = new AppUserListViewModel();
            ;
            //model.Id = user.Id;
            //model.Name = user.Name;
            //model.Surname = user.Surname;
            //model.Username = user.UserName;
            //model.Email = user.Email;
            //model.Picture = user.Picture;

            return View(_mapper.Map<AppUserListDto>(await LoginUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(i => i.Id == model.Id);
                if (picture != null)
                {
                    string picName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + picName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await picture.CopyToAsync(stream);
                    }
                    user.Picture = picName;
                }
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["message"] = "User is updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    Error(result.Errors);
                }
            }

            return View(model);
        }
    }
}
