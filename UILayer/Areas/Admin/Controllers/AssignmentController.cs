using AutoMapper;
using BusinessLayer.Interfaces;
using DTOService.DTOs.AppUserDTOs;
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
using UILayer.StringInfo;

namespace UILayer.Areas.Admin.Controllers
{
    [Authorize(Roles = AreaInfos.Admin)]
    [Area(RoleInfos.Admin)]
    public class AssignmentController : Controller
    {
        IAppUserService _userService;
        IWorkService _workService;
        UserManager<AppUser> _userManager;
        IFilesManager _filesManager;
        IMapper _mapper;
        INotificationService _notificationService;
        public AssignmentController(IAppUserService userService, IWorkService workService, UserManager<AppUser> userManager, IFilesManager filesManager, INotificationService notificationService, IMapper mapper)
        {
            _mapper = mapper;
            _notificationService = notificationService;
            _filesManager = filesManager;
            _userService = userService;
            _userManager = userManager;
            _workService = workService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Assigment;
            List<Work> works = _workService.AllData();


            //List<WorkListAllDto> models = new List<WorkListAllDto>();
            //foreach (var item in works)
            //{
            //    WorkListAllViewModel model = new WorkListAllViewModel();
            //    model.Description = item.Description;
            //    model.Name = item.Name;
            //    model.Id = item.Id;
            //    model.urgency = item.urgency;
            //    model.CreateTime = item.CreateTime;
            //    model.appUser = item.appUser;
            //    model.reports = item.reports;
            //    models.Add(model);

            //}


            return View(_mapper.Map<List<WorkListAllDto>>(_workService.AllData()));
        }

        public IActionResult assigment(int id, string searchWord, int Page = 1)
        {
            TempData["Active"] = TempDataInfo.Assigment;
            ViewBag.ActivePage = Page;
            int sumPage;
            ViewBag.Searched = searchWord;
            //ViewBag.SumPage = (int)Math.Ceiling((double)_userService.AllMembers().Count / 3);
            var work = _workService.GetByUrgencyId(id);


            var users = _mapper.Map<List<AppUserListDto>>(_userService.AllMembers(out sumPage, searchWord, Page));
            ViewBag.Sumpage = sumPage;
            //foreach (var item in users)
            //{
            //    AppUserListViewModel model = new AppUserListViewModel();
            //    model.Id = item.Id;
            //    model.Name = item.Name;
            //    model.Surname = item.Surname;
            //    model.Username = item.Username;
            //    model.Email = item.Email;
            //    model.Picture = item.Picture;
            //    userModel.Add(model);

            //}

            ViewBag.users = users;

            WorkListViewModel Workmodel = new WorkListViewModel();
            Workmodel.Id = work.Id;
            Workmodel.Name = work.Name;
            Workmodel.Description = work.Description;
            Workmodel.urgency = work.urgency;
            Workmodel.CreateTime = work.CreateTime;

            return View(_mapper.Map<WorkListDto>(_workService.GetByUrgencyId(id)));
        }

        public IActionResult AssignUserWorks(UserWorksDto model)
        {


            TempData["Active"] = TempDataInfo.Assigment;
            var user = _userManager.Users.FirstOrDefault(i => i.Id == model.UserId);
            var work = _workService.GetByUrgencyId(model.WorkId);

            var userModel = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(i => i.Id == model.UserId));

            //userModel.Email = user.Email;
            //userModel.Id = user.Id;
            //userModel.Name = user.Name;
            //userModel.Surname = user.Surname;
            //userModel.Username = user.UserName;
            //userModel.Picture = user.Picture;

            //WorkListViewModel workModel = new WorkListViewModel();
            var workModel = _mapper.Map<WorkListDto>(_workService.GetByUrgencyId(model.WorkId));
            //workModel.Description = work.Description;
            //workModel.CreateTime = work.CreateTime;
            //workModel.Name = work.Name;
            //workModel.Id = work.Id;
            //workModel.urgency = work.urgency;
            UserWorksListDto UserWorkModel = new UserWorksListDto();
            UserWorkModel.appUser = userModel;
            UserWorkModel.work = workModel;
            return View(UserWorkModel);

        }
        [HttpPost]
        public IActionResult assigment(UserWorksDto model)
        {

            var work = _workService.GetEntityById(model.WorkId);
            work.AppUserId = model.UserId;
            _notificationService.Save(new Notification
            {
                AppUserId = model.UserId,
                Description = $"you have been appointed { work.Name}"
            });
            _workService.Update(work);
            return RedirectToAction("Index");
        }

        public IActionResult details(int Id)
        {

            TempData["Active"] = TempDataInfo.Assigment;
            var work = _workService.GetReportById(Id);

            //WorkListAllViewModel model = new WorkListAllViewModel();
            //model.Description = work.Description;
            //model.Name = work.Name;
            //model.Id = work.Id;
            //model.appUser = work.appUser;
            //model.urgency = work.urgency;
            //model.reports = work.reports;


            return View(_mapper.Map<WorkListAllDto>(_workService.GetReportById(Id)));
        }


        public IActionResult getExcel(int Id)
        {
            return File(_filesManager.giveExcel(_mapper.Map<List<ReportFileDto>>(_workService.GetReportById(Id).reports)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }
        public IActionResult getPDF(int Id)
        {
            var path = _filesManager.AktarPdf(_mapper.Map<List<ReportFileDto>>(_workService.GetReportById(Id).reports));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
        //public IActionResult GetirExcel(int id)
        //{
        //    return File(_filesManager.AktarExcel(_workService.GetReportById(id).reports), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        //}

        //public IActionResult GetirPdf(int id)
        //{
        //    var path = _filesManager.AktarPdf(_workService.GetReportById(id).reports);
        //    return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        //}

    }
}
