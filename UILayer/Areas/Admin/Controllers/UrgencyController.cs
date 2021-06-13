using AutoMapper;
using BusinessLayer.Interfaces;
using DTOService.DTOs.UrgencyDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;

        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _mapper = mapper;
            _urgencyService = urgencyService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Urgency;
            //List<Urgency> urgencies = _urgencyService.AllEntitys();
            //List<UrgencyListViewModel> model = new List<UrgencyListViewModel>();
            //foreach (var item in urgencies)
            //{

            //    UrgencyListViewModel urgencyModel = new UrgencyListViewModel();
            //    urgencyModel.Id = item.Id;
            //    urgencyModel.Definition = item.Definition;
            //    model.Add(urgencyModel);
            //}
            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.AllEntitys()));
        }
        public IActionResult List()
        {
            TempData["Active"] = TempDataInfo.Urgency;
            return View();
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = TempDataInfo.Urgency;
            return View(new UrgencyAddDto());

        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Save(new Urgency()
                {
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }


            return View(model);

        }

        public IActionResult updateUrgency(int Id)
        {
            TempData["Active"] = TempDataInfo.Urgency;
            //var updateUrgency = _urgencyService.GetEntityById(Id);
            //UrgencyUpdateViewModel model = new UrgencyUpdateViewModel
            //{
            //    Id = updateUrgency.Id,
            //    Definition = updateUrgency.Definition
            //};
            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.GetEntityById(Id)));
        }
        [HttpPost]
        public IActionResult updateUrgency(UrgencyUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Update(new Urgency
                {
                    Definition = model.Definition,
                    Id = model.Id
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
