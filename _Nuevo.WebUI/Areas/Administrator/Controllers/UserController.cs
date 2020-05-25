using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Nuevo.Business.Interfaces;
using _Nuevo.DTO.Objects.AppUserDTOs;
using _Nuevo.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Nuevo.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;
        private readonly ICustomLogger _customLogger;
        public UserController(UserManager<AppUser> userManager, IMapper mapper, IAppUserService userService, ICustomLogger customLogger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
            _customLogger = customLogger;
        }
        public IActionResult Index(string search, int page = 1)
        {
            TempData["Active"] = "User";
            ViewBag.CurrentPage = page;
            ViewBag.Searched = (!string.IsNullOrWhiteSpace(search) ? search : "");
            var model = _mapper.Map<List<AppUserListDto>>(_userService.GetList(out var count, page, search));
            ViewBag.Count = count;
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _mapper.Map<AppUserListDto>(_userManager.Users.First(u => u.Id == id));
            if (model != null)
                return View(model);
            else
                _customLogger.Error("UserController | Update User Error : Null Object");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppUserListDto model)
        {
            if (!ModelState.IsValid) return View(model);
            var obj = _userManager.Users.FirstOrDefault(u => u.Id == model.Id);
            if (obj == null) return View(model);
            obj.Name = model.Name;
            obj.Surname = model.Surname;
            obj.Email = model.Email;
            obj.UserName = model.Username;
            var result = await _userManager.UpdateAsync(obj);
            if (result.Succeeded)
            {
                _customLogger.Information("UserController | Updated User : " + obj.Email);
                return RedirectToAction("Index");
            }
            else
                _customLogger.Error("UserController | Updated User Error ");
            return View(model);
        }
        public IActionResult Insert()
        {
            return View(new AppUserAddDto());
        }
        [HttpPost]
        public async Task<IActionResult> Insert(AppUserAddDto model)
        {
            if (!ModelState.IsValid) return View(model);
            var obj = _mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(obj, model.Password);
            if (!result.Succeeded) return View(model);
            IEnumerable<string> data = new List<string>
            {
                "Administrator"
            };
            var roleResult = await _userManager.AddToRolesAsync(obj, data);
            if (roleResult.Succeeded)
            {
                _customLogger.Information("UserController | Added New User : " + obj.Email);
                return RedirectToAction("Index");
            }
            foreach (var item in roleResult.Errors)
            {
                _customLogger.Error("UserController | Insert User Error : " + obj.Email);
                ModelState.AddModelError("", item.Description);
            }
            return View(model);
        }
    }
}
