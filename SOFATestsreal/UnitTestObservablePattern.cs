using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Moq;
using Softwareontwerp_en_architectuur.Domain;
using Softwareontwerp_en_architectuur.Domain.Notifier;
using Softwareontwerp_en_architectuur.Domain.State;

namespace SOFATestsreal
{
    public class UnitTestObsorvablePattern
    {
        [Fact]
        public void ObserverTestNotificationNoMocking()
        {
            //Arrange
            Developer dev = new Developer();

            BacklogItem item = new BacklogItem("Make work", "Make sure this method works", "It works");
            EmailNotifier notifier = new EmailNotifier();
            item.Subscribe(notifier);

            //Act
            item.SendTesterNotification("Yeah");
            //Assert
            Assert.Single(notifier.receivedMessages);
            Assert.Equal("Yeah", notifier.receivedMessages[0]);
        }
        [Fact]
        public void ObserverTestNotificationMocking()
        {
            //Arrange
            Developer dev = new Developer();
            BacklogItem item = new BacklogItem("Make work", "Make sure this method works", "It works");
            var mockNotifier = new Mock<INotifier>();
            item.Subscribe(mockNotifier.Object);
            //Act
            item.SendTesterNotification("Yeah");
            //Assert
            mockNotifier.Verify(x => x.SendNotification(It.IsAny<string>()), Times.Once);
        }
    }
}
