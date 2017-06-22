using System;
using System.Threading.Tasks;
using MLNotification.Domain;
using MLNotification.ServiceClientConnect.EventArgs;

namespace MLNotification.ServiceClientConnect
{
    public interface IMLMessageHubConect
    {
        event EventHandler<MLMessageEventArgs> ProcessMessage;

        void Dispose();
        Task SendMessage(NotificationMessage message);
    }
}