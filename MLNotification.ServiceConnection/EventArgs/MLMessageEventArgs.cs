using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLNotification.Domain;

namespace MLNotification.ServiceClientConnect.EventArgs
{
    public class MLMessageEventArgs
    {
        public NotificationMessage NotificationMessage { get; private set; }

        public MLMessageEventArgs(NotificationMessage notificationMessage)
        {
            NotificationMessage = notificationMessage;
        }
    }
}
