using AutoMapper;
using BusinessLayer.Interfaces;
using DTOService.DTOs.WorkDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class WorkController : Controller
    {
        IWorkService _workService;
        IUrgencyService _urgencyService;
        IMapper _mapper;
        public WorkController(IWorkService workService, IUrgencyService urgencyService, IMapper mapper)
        {
            _workService = workService;
            _mapper = mapper;
            _urgencyService = urgencyService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Work;
            List<Work> works = _workService.NotFinished();
            //foreach (var item in works)
            //{
            //    WorkListViewModel model = new WorkListViewModel
            //    {
            //        Description = item.Description,
            //        State = item.State,
            //        Name = item.Name,
            //        Id = item.Id,
            //        CreateTime = item.CreateTime,
            //        urgency = item.urgency,
            //        UrgencyId = item.UrgencyId
            //    };
            //    models.Add(model);
            //}
            return View(_mapper.Map<List<WorkListDto>>(_workService.NotFinished()));
        }
        public IActionResult AddWork()
        {
            TempData["Active"] = TempDataInfo.Work;
            ViewBag.Urgency = new SelectList(_urgencyService.AllEntitys(), "Id", "Definition");
            return View(new WorkAddDto());
        }
        [HttpPost]
        public IActionResult AddWork(WorkAddDto model)
        {
            if (ModelState.IsValid)
            {
                _workService.Save(new Work
                {
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId

                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult updateWork(int Id)
        {
            TempData["Active"] = TempDataInfo.Work;
            var work = _workService.GetEntityById(Id);
           
            //WorkUpdateViewModel model = new WorkUpdateViewModel
            //{
            //    Description = work.Description,
            //    Name = work.Name,
            //    UrgencyId = work.UrgencyId,
            //    Id = work.Id
            //};
            ViewBag.Urgency = new SelectList(_urgencyService.AllEntitys(), "Id", "Definition", work.UrgencyId);
            return View(_mapper.Map<WorkUpdateDto>(_workService.GetEntityById(Id)));
        }
        [HttpPost]
        public IActionResult updateWork(WorkUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _workService.Update(new Work
                {
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId,
                    Id = model.Id
                });
                return RedirectToAction("Index");
            }
            ViewBag.Urgency = new SelectList(_urgencyService.AllEntitys(), "Id", "Definition", model.UrgencyId);
            return View(model);
        }


        public IActionResult deleteWork(int id)
        {
            TempData["Active"] = TempDataInfo.Work;
            _workService.Delete(new Work{Id = id});
            return Json(null);
        }
    }
}
