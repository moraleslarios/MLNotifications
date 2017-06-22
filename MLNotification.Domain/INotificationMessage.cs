using System;
using System.Drawing;

namespace MLNotification.Domain
{
    public interface INotificationMessage : IUserInfo
    {
        string      Body        { get; set; }
        string      UriImage    { get; set; }
        DateTime    MessageDate { get; set; }
        MessageType MessageType { get; set; }
        string      Subject     { get; set; }

    }
}