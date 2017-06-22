using Microsoft.AspNet.SignalR;
using MLNotification.Domain;
using System;
using System.Threading.Tasks;

namespace MLNotification.Service
{
    public class MLMessageHub : Hub
    {
        async public override Task OnConnected()
        {
            //Console.WriteLine("Nueva conexion con Id=" + Context.ConnectionId);

            //var message = new NotificationMessage
            //{
            //    Subject     = "New service connection",
            //    Body        = $"There is a new connection from the UserId:{Context.ConnectionId}",
            //    MessageDate = DateTime.Now,
            //    MessageType = MessageType.Information
            //};

            //await Clients.Caller.ProcessMessage(message);
            //await Clients.Others.ProcessMessage(message);
        }
        async public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Nueva conexion con Id=" + Context.ConnectionId);

            var message = new NotificationMessage
            {
                Subject     = "New service desconnection",
                Body        = $"There is a desconnection from the UserId:{Context.ConnectionId}",
                MessageDate = DateTime.Now,
                MessageType = MessageType.Information,
                UriImage    = "http://www.tampabay.com/resources/images/dti/rendered/2015/04/wek_plug041615_15029753_8col.jpg"
            };

            await Clients.Caller.ProcessMessage(message);
            await Clients.Others.ProcessMessage(message);
        }

        async public Task SendMessage(NotificationMessage message)
        {
            Console.WriteLine("[" + message.User + "]: " + message.Body);
            await Clients.All.ProcessMessage(message);
        }


        async public Task RegisterUser(UserInfo userInfo)
        {
            //if (userInfo == null) userInfo = new UserInfo { User = Context.ConnectionId, Group = string.Empty, Server = "Not Info Server" };

            //this.userInfo = userInfo;

            //System.Threading.Thread.Sleep(2000);

            //Console.WriteLine($"[User {userInfo.User} register at {DateTime.Now}]: ");

            //var message = new NotificationMessage { Body = $"User {userInfo.User} conected at {DateTime.Now}", Subject = $"User {userInfo.User}", User = userInfo.User,
            //    MessageType = MessageType.Information, MessageDate = DateTime.Now, Group = userInfo.Group, Server = userInfo.Server,
            //    UriImage = "http://www.iconhot.com/icon/png/glossy/512/plug-5.png"};

            //await Clients.All.ProcessMessage(message);
        }

    }
}
