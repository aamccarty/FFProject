using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FFProject.Controllers
{
    public class TradeOffersController : Controller
    {
        public IActionResult TradePage()
        {
            return View();
        }
    }
}