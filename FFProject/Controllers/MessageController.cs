using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFProject.Models;
using FFProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FFProject.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        IMessage repo;
        public MessageController(IMessage m)
        {
            repo = m;
        }
        
        public ViewResult FormPage()
        {
            List<Message> message = repo.Messages;
            return View(message);
        }
        [HttpGet]
        public IActionResult FormMessage()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult FormMessage(string messageText, string messenger)
        {
            if (ModelState.IsValid)
            {
                AppUser u = new AppUser() { UserName = messenger };
                Message message = new Message()
                {
                    Messenger = u,
                    MessageText = messageText
                };
                message.MessageText = messageText;
                repo.AddMessage(message, u);
            }
            return RedirectToAction("FormPage");
        }
        public RedirectToActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("FormPage");
        }



    }
}