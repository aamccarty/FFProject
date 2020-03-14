using FFProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Repository
{
    public class MessageRepo : IMessage
    {
        private ApplicationDbContext context;
        public List<Message> Messages { get { return context.Messages.Include("Messenger").ToList(); } }
    
        public MessageRepo(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public void AddMessage(Message message, AppUser user)
        {
                context.Messages.Update(message);
                context.Users.Add(message.Messenger);
                context.Messages.Add(message);
                context.SaveChanges();
        }
        public Message GetMessageByName(AppUser user)
        {
            Message message;
            message = context.Messages.First(s => s.Messenger == user);
            return message;
        }
        public Message GetMessageByID(int id)
        {
            return context.Messages.First(a => a.MessageID == id);
        }
        public int Edit(Message message)
        {
            context.Messages.Update(message);
            return context.SaveChanges();
        }
     
        public int Delete(int id)
        {
            var messageDB = context.Messages.First(a => a.MessageID == id);
            context.Remove(messageDB);
            return context.SaveChanges();
        }
        
    }
}
