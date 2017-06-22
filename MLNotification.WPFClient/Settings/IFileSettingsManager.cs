namespace MLNotification.WPFClient.Settings
{
    public interface IFileSettingsManager
    {
        bool ExistsSettingsFile(string fileSettingsPath);
        void WriteSettingsFile(string fileSettingsPath, SettingsInfo settingsInfo);
        SettingsInfo ReadSettingsFile(string fileSettingsPath);
    }
}