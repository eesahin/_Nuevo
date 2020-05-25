using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using _Nuevo.Business.Interfaces;
using _Nuevo.DTO.Objects.TagetDTOs;
using _Nuevo.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _Nuevo.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["Active"] = "Home";
            return View();
        }
        [HttpGet]
        public IActionResult Items()
        {
            TempData["Active"] = "Home";
            return View();
        }
    }
}
