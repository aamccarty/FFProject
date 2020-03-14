using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FFProject.Models;
using Microsoft.AspNetCore.Authorization;
using FFProject.Repository;
using System.Threading.Tasks;

namespace FFProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //IFootball Repository;
       /* public HomeController(IFootball r)
        {
            Repository = r;
        }*/
        public IActionResult Index()
        {
            ViewBag.welcome = "WELCOME";
            ViewData["Date"] = DateTime.Now.Date.ToString("MM-dd-yyyy");
            ViewData["Time"] = DateTime.Now.ToString("t");
            return View();
        }

         [AllowAnonymous]
        public IActionResult Links()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
    }
}
