namespace MLNotification.WPFClient
{
    using System;

    [Serializable]
    public class SettingsInfo
    {
        public string ServiceAddress { get; set; }
        public int SecondsVisibilityBallonTime { get; set; }
        public bool ShowBallonWithNotificationsOpen { get; set; }
    }
}