using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLNotification.Domain;
using MLNotification.ServiceClientConnect;
using MLNotification.WPFClient.ViewModel;
using Xunit;
using Moq;

namespace MLNotification.WPFClient.Tests.ViewModels
{
    public class NotificationViewModelTests
    {
        private NotificationViewModel instance;

        private Mock<MLMessageHubConect> moqMessageHub;

        //public NotificationViewModelTests()
        //{
        //    moqMessageHub = new Mock<MLMessageHubConect>(null, null);

        //    instance = new NotificationViewModel(moqMessageHub.Object);
        //}

        //[Fact]
        //public void ProcessMessageEvent_AddNotifications_OK()
        //{
        //    NotificationMessage message = new NotificationMessage { Subject = "Automatic Message", Body = "Body of Automatic Message" };

        //    moqMessageHub.Object.OnProcessMessage(message);

        //    Assert.Equal(1, instance.Notifications.Count);
        //    Assert.Equal(message.Subject, instance.Notifications.First().Subject);
        //    Assert.Equal(message.Body, instance.Notifications.First().Body);
        //}

    }
}
