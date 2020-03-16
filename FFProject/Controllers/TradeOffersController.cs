using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace FFProject.Controllers
{
    public class TradeOffersController : Controller
    {
        [Authorize]
        public IActionResult TradePage()
        {
            return View();
        }
    }
}