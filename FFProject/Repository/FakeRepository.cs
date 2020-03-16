using FFProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Repository
{
    public class FakeRepository : IMessage
    {
        private List<Message> messages = new List<Message>();
        private List<AppUser> users = new List<AppUser>();


        public FakeRepository()
        {
            if (messages.Count == 0) { AddTestMessages(); }
        }

        private void AddTestMessages()
        {
            Message m1 = new Message()
            {
                MessageID = 0,
                MessageText = "The Site is Working",
            };
            m1.Messenger = (new AppUser() { UserName = "Aaron" });
            messages.Add(m1);
            Message m2 = new Message()
            {
                MessageID = 1,
                MessageText = "The Site better be Working",
            };
            m2.Messenger = (new AppUser() { UserName = "Bob" });
            messages.Add(m2);

        }

        public List<Message> Messages => messages;
        private List<AppUser> Users => users;


        public void AddMessage(Message message, AppUser user)
        {
            Messages.Add(message);
            Users.Add(message.Messenger);
        }
        public Message GetMessageByName(AppUser user)
        {
            Message message;
            message = Messages.First(s => s.Messenger == user);
            return message;
        }
        public Message GetMessageByID(int id)
        {
            return Messages.First(a => a.MessageID == id);
        }
        public int Edit(Message m)
        {
            return m.MessageID;
        }

        public int Delete(int id)
        {
            var messageDB = Messages.First(a => a.MessageID == id);
            messages.Remove(messageDB);
            return id;
        }
    }
}
