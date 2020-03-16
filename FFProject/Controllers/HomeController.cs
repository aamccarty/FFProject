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
        IFootball Repository;
        public HomeController(IFootball r)
        {
            Repository = r;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.welcome = "WELCOME";
            ViewData["Date"] = DateTime.Now.Date.ToString("MM-dd-yyyy");
            ViewData["Time"] = DateTime.Now.ToString("t");
            List<Roster> roster = Repository.Rosters;
            return View(roster);
        }

        public IActionResult PlayerAdd()
        {
            return View();
        }

        
        public IActionResult TradeOffer()
        {
            return View();
        }
        
        [HttpPost]
        public RedirectToActionResult PlayerAdd(string playername, string playerposition, int playervalue)
        {
            if (ModelState.IsValid)
            {
                Roster roster = new Roster()
                {
                    PlayerName = playername,
                    PlayerPosition = playerposition,
                    PlayerValue = playervalue
                };
                Repository.AddPlayer(roster);
            }
            return RedirectToAction("Index");
        }
        /*
        [HttpPost]
        public RedirectToActionResult TradeOffer(string playername, string playerposition, int playervalue)
        {
            if (ModelState.IsValid)
            {

                Roster offer = new Roster()
                {
                    PlayerName = playername,
                    PlayerPosition = playerposition,
                    PlayerValue = playervalue
                };
                Repository.AddTrade(offer);

                

            }
            return RedirectToAction("TradeOffer");
        }
        */

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

        public RedirectToActionResult Delete(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
