using System;
using Xunit;
using FFProject.Controllers;
using FFProject.Models;
using FFProject.Repository;
using System.Collections.Generic;

namespace FantasyFootballTests
{
    public class MessageTests
    {
        [Fact]
        public void MessageCountTest()
        {
            // Arrange
            var repo = new FakeRepository();
            var messageController = new MessageController(repo);

            // Act
            messageController.FormMessage();
            // Assert
            Assert.Equal(2, repo.Messages.Count);
        }

        [Fact]
        public void AddMessage()
        {
            // Arrange
            var repo = new FakeRepository();

            Message m3 = new Message
            {
                MessageID = 2,
                MessageText = "Let the Test Roll",
            };
            m3.Messenger = (new AppUser() { UserName = "Chad" });
            // Act
            repo.Messages.Add(m3);


            // Assert
            Assert.Equal(3, repo.Messages.Count);
           
            
        }

        [Fact]
        public void GetMessagetest()
        {
            // Arrange
            var repo = new FakeRepository();

            Message m3 = new Message
            {
                MessageID = 3,
                MessageText = "Name Test",
            };
            m3.Messenger = (new AppUser() { UserName = "Duncan" });
            // Act
            repo.Messages.Add(m3);

            // Assert
            Assert.Same(m3.MessageText, "Name Test");
            

        }
        [Fact]
        public void DeleteMessageTest()
        {
            // Arrange
            var repo = new FakeRepository();
            var messageController = new MessageController(repo);

            Message m3 = new Message
            {
                MessageID = 3,
                MessageText = "Name Test",
            };
            m3.Messenger = (new AppUser() { UserName = "Duncan" });
            // Act
            repo.Messages.Add(m3);
            Assert.Equal(3, repo.Messages.Count);
            
            repo.Delete(3);

            Assert.Equal(2, repo.Messages.Count);
        }
    }
    
}
