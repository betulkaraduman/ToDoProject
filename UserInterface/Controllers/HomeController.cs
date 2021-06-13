using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterface.CustomExtensions;
using UserInterface.CustomFilters;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SetSesson();
            ViewBag.Cookie = GetSession();
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [NameCharactersState]
        [HttpPost]
        public IActionResult Register2(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            ModelState.AddModelError(nameof(UserRegisterViewModel.Name), "Name is required");
            ModelState.AddModelError("", "About Models");
            return View("Register", model);
        }
        public void SetCookie()
        {
            HttpContext.Response.Cookies.Append("user", "betul", new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5),
                HttpOnly = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            });
        }
        public string GetCookie()
        {
            return HttpContext.Request.Cookies["user"];
        }
        public void SetSesson()
        {
            HttpContext.Session.SetObject("user", new UserRegisterViewModel() { Name = "Betul", Surname = "Karaduman" });
        }
        public UserRegisterViewModel GetSession()
        {
            return HttpContext.Session.GetObject<UserRegisterViewModel>("user");
        }

        public IActionResult PageError(int code)
        {
            ViewBag.Code = code;
            if (code == 404)
            {
                ViewBag.ErrorMessage = "Page is not found";
            }
            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            CustomLogger.NLogLogger nlogLogger= new CustomLogger.NLogLogger();
            nlogLogger.LogWithNLog($"Eroor path : {exceptionHandlerPathFeature.Path}/n Error Message : {exceptionHandlerPathFeature.Error.Message}\n stack trace : {exceptionHandlerPathFeature.Error.StackTrace}");
            ViewBag.Path = exceptionHandlerPathFeature.Path;
            ViewBag.Message = exceptionHandlerPathFeature.Error.Message;



            return View();
        }

        public IActionResult Hata()
        {
            throw new Exception("Hata oluştu");

        }
    }
}