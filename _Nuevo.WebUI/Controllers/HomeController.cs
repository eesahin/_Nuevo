using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Nuevo.Business.Interfaces;
using _Nuevo.DTO.Objects.AppUserDTOs;
using _Nuevo.Entities.Concrete;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Nuevo.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomLogger _customLogger;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomLogger customLogger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _customLogger = customLogger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync
                        (model.Username, model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        var userRole = await _userManager.GetRolesAsync(user);
                        if (userRole.Contains("Administrator"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Administrator" });
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı...");
            }
            _customLogger.Information("Login Error...");
            return View("Index", model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
