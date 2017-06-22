using System;
using MLNotification.WPFClient;

namespace MLNotification.WPFClient.Settings
{
    public class SettingsManager : ISettingsManager
    {
        private IFileSettingsManager fileSettingsManager;

        public SettingsManager(IFileSettingsManager fileSettingsManager)
        {
            this.fileSettingsManager = fileSettingsManager;
        }

        public SettingsInfo ReadSettings()
        {
            var result = new SettingsInfo();

            if (fileSettingsManager.ExistsSettingsFile(SettingsGlobalData.PathFileSettingsName))
            {
                result = fileSettingsManager.ReadSettingsFile(SettingsGlobalData.PathFileSettingsName);
            }
            else
            {
                result = new SettingsInfo { ServiceAddress = "http://localhost:11111", SecondsVisibilityBallonTime = 4, ShowBallonWithNotificationsOpen = false };

                fileSettingsManager.WriteSettingsFile(SettingsGlobalData.PathFileSettingsName, result);
            }

            return result;
        }

        public void WriteSettings(SettingsInfo settingsInfo)
        {
            if (settingsInfo == null) throw new ArgumentNullException(nameof(settingsInfo), $"The parameter {nameof(settingsInfo)} can't be null");

            fileSettingsManager.WriteSettingsFile(SettingsGlobalData.PathFileSettingsName, settingsInfo);
        }
    }
}