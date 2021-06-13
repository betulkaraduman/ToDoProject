using AutoMapper;
using BusinessLayer.Interfaces;
using DTOService.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UILayer.BaseControllers;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        ICustomLogger _customLogger;
        public HomeController(UserManager<AppUser> userManager,  SignInManager<AppUser> signInManager,ICustomLogger customLogger):base(userManager)
        {
            _customLogger = customLogger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var rols = await _userManager.GetRolesAsync(user);
                        if (rols.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("", "Username or passwprd not correct");
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"Error area : {exceptionHandler.Path}\nError Message : {exceptionHandler.Error.Message}\n Stack Trace : {exceptionHandler.Error.StackTrace}");
           ViewBag.Path= exceptionHandler.Path;
           ViewBag.Path= exceptionHandler.Error.Message;
            return View();


            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void Hata()
        {
            throw new Exception("this is an error");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Username,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var identityResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (identityResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    Error(identityResult.Errors);
                }
                Error(result.Errors);
            }


            return View(model);
        }


       
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

      
        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {

                ViewBag.Code = code;
                ViewBag.Message = "Page is not found";
            }
            return View();
        }
    }
}
