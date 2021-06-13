using AutoMapper;
using BusinessLayer.Interfaces;
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
    public class WorkController : BaseIdentityController
    {
        IWorkService _workService;
        IMapper _mapper;

        public WorkController(IWorkService workService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
            _workService = workService;
        }
         public async Task<IActionResult> Index(int activePage=1)
        {
            TempData["Active"] = TempDataInfo.Work;
            var user =await LoginUser();
            int sumPage;
            var works = _mapper.Map<List<WorkListAllDto>>(_workService.AllDataNotFinished(out sumPage, user.Id, activePage));
            ViewBag.SumPage = sumPage;
            ViewBag.AktivePage = activePage;

            

            //List<WorkListAllViewModel> models = new List<WorkListAllViewModel>();
            //foreach (var work in works)
            //{
            //    WorkListAllViewModel model = new WorkListAllViewModel();
            //    model.Name = work.Name;
            //    model.Description = work.Description;
            //    model.urgency = work.urgency;
            //    model.Id = work.Id;
            //    model.appUser = work.appUser;
            //    model.CreateTime = work.CreateTime;
            //    model.reports = work.reports;
            //    models.Add(model);
               
            //}
            return View(works);
        }
    }
}
