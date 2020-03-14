using FFProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Repository
{
    public interface IMessage
    {
        List<Message> Messages { get; }
        public void AddMessage(Message message, AppUser user);
        Message GetMessageByName(AppUser user);
        Message GetMessageByID(int id);
        int Edit(Message message);
        int Delete(int id);


    }
}
