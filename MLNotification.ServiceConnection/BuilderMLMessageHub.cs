using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLNotification.Domain;

namespace MLNotification.ServiceClientConnect
{
    public class BuilderMLMessageHubConnect
    {
        public static MLMessageHubConect CreateMLMessageHub(string address, IUserInfo userInfo = null, bool isDefaultConnect = true)
        {
            HubConnection conexionHub = new HubConnection(address, isDefaultConnect);
            IHubProxy proxyHub = conexionHub.CreateHubProxy("MLMessageHub");

            try
            {
                var result = new MLMessageHubConect(conexionHub, proxyHub, userInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }


    }
}
