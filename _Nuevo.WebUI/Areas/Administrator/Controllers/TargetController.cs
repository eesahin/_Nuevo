using System;
using System.Collections.Generic;
using System.Linq;
using _Nuevo.Business.Interfaces;
using _Nuevo.DTO.Objects.TagetDTOs;
using _Nuevo.Entities.Concrete;
using _Nuevo.WebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace _Nuevo.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class TargetController : BaseIdentityController
    {
        private readonly ITargetService _targetService;
        private readonly IMapper _mapper;
        private readonly ICustomLogger _customLogger;
        public TargetController(ITargetService targetService, IMapper mapper, UserManager<AppUser> userManager, ICustomLogger customLogger) : base(userManager)
        {
            _targetService = targetService;
            _mapper = mapper;
            _customLogger = customLogger;
        }
        public IActionResult Index(string search, int page = 1)
        {
            TempData["Active"] = "Target";
            ViewBag.CurrentPage = page;
            ViewBag.Searched = (!string.IsNullOrWhiteSpace(search) ? search : "");
            var model = _mapper.Map<List<TargetListDto>>(_targetService.GetList(out var count, page, search));
            ViewBag.Count = count;
            return View(model);
        }
        public IActionResult Insert()
        {
            return View(new TargetAddDto
            {
                StartOfPeriod = DateTime.Now,
                EndOfPeriod = DateTime.Now,
            });
        }
        [HttpPost]
        public IActionResult Insert(TargetAddDto model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = GetCurrentUser().Result.Id;
            model.LastModified = DateTime.Now;
            var obj = _mapper.Map<Target>(model);
            try
            {
                _targetService.Add(obj);
                _customLogger.Information("TargetController | Added New Target : " + obj.Name);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _customLogger.Error("TargetController | Insert Target Error " + e.Message.ToString());
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _mapper.Map<TargetUpdateDto>(_targetService.GetItem(id));
            if (model != null)
                return View(model);
            else
                _customLogger.Error("TargetController | Update Target Error : Null Object");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(TargetUpdateDto model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = model.UserId = GetCurrentUser().Result.Id;
            model.LastModified = DateTime.Now;
            var obj = _mapper.Map<Target>(model);
            try
            {
                _targetService.Update(obj);
                _customLogger.Information("Updated Target : " + obj.Name);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _customLogger.Error("TargetController | Update Target Error..." + e.Message.ToString());
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _targetService.Delete(new Target { Id = id });
            return Json(null);
        }
        [HttpGet]
        public IActionResult UpdateStatu(int id)
        {
            var target = _targetService.GetItem(id);
            var statu = target.IsWork;
            target.IsWork = (!statu);
            try
            {
                _targetService.Update(target);
                _customLogger.Information("Updated Target Statu : " + target.Name);
            }
            catch (Exception e)
            {
                _customLogger.Error("TargetController | Updated Target Statu Error..." + e.Message.ToString());
            }
            return Json(true);
        }
        [HttpGet]
        public JsonResult Items()
        {
            var data = _targetService.GetListForHomePage();
            List<TargetForHomePage> resultData = new List<TargetForHomePage>();
            foreach (var item in data)
            {
                var model = new TargetForHomePage
                {
                    id = item.Id,
                    name = item.Name,
                    statusCode = item.Status.LastOrDefault()?.Code,
                    url = item.Url
                };
                resultData.Add(model);
            }
            return new JsonResult(resultData);
        }
    }
}
