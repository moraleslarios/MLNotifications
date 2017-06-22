using Microsoft.AspNet.SignalR.Client;
using MLNotification.Domain;
using MLNotification.ServiceClientConnect.EventArgs;
using System;
using System.Threading.Tasks;

namespace MLNotification.ServiceClientConnect
{
    public class MLMessageHubConect : IDisposable, IMLMessageHubConect
    {
        public HubConnection conexionHub = null;
        private IHubProxy     proxyHub   = null;

        public IUserInfo userInfo;

        private const string NotificationMessageStr = "ProcessMessage";
        private const string SendMessageStr         = "SendMessage";
        private const string RegisterUserStr        = "RegisterUser";

        private bool isConnect = false;

        public event EventHandler<MLMessageEventArgs> ProcessMessage;



        public MLMessageHubConect(HubConnection conexionHub, IHubProxy proxyHub, IUserInfo userInfo = null)
        {
            this.conexionHub = conexionHub;
            this.proxyHub    = proxyHub;

            this.userInfo = userInfo;

            Connect();

            RegisterUser(userInfo);
        }

        private void Connect()
        {
            try
            {

                proxyHub.On(NotificationMessageStr, (NotificationMessage message) =>
                {
                    if (message != null && conexionHub != null)
                    {
                        OnProcessMessage(message);
                    }
                });

                Task.WaitAll(conexionHub.Start());

                RegisterUser(userInfo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error " + ex.Message);

                throw new HubException($"Error to connect to Service. Check the service is online, and the ServiceAddress is correct. Error:{ex.Message}");
            }
        }


        public Task SendMessage(NotificationMessage message)
        {
            //message.User = userInfo.User;

            return proxyHub.Invoke(SendMessageStr, message);
        }

        public void SendMessage2(NotificationMessage message)
        {
            proxyHub.Invoke(SendMessageStr, message).Wait();
        }

        public Task RegisterUser(IUserInfo userInfo)
        {
            return proxyHub.Invoke(RegisterUserStr, userInfo);
        }

        protected internal virtual void OnProcessMessage(NotificationMessage message) => ProcessMessage?.Invoke(this, new MLMessageEventArgs(message));


        public void Dispose()
        {
            isConnect = false;

            conexionHub.Dispose();
            conexionHub = null;
            proxyHub    = null;
        }
    }
}
