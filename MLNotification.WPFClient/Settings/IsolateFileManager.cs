using System;
using MLNotification.WPFClient;
using System.IO.IsolatedStorage;
using System.IO;

namespace MLNotification.WPFClient.Settings
{
    public class IsolateFileManager : IFileSettingsManager
    {
        //rivate IsolatedStorageFile isolatedStorage;

        public IsolateFileManager(IsolatedStorageFile isolatedStorage)
        {
            //this.isolatedStorage = isolatedStorage;
        }

        public bool ExistsSettingsFile(string fileSettingsPath)
        {
            if(string.IsNullOrWhiteSpace(fileSettingsPath)) throw new ArgumentNullException(nameof(fileSettingsPath), $"The parameter {nameof(fileSettingsPath)} can't be null/white/white space");

            var isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            bool result = isolatedStorage.FileExists(fileSettingsPath);

            isolatedStorage.Dispose();

            return result;
        }

        public SettingsInfo ReadSettingsFile(string fileSettingsPath)
        {
            if (string.IsNullOrWhiteSpace(fileSettingsPath)) throw new ArgumentNullException(nameof(fileSettingsPath), $"The parameter {nameof(fileSettingsPath)} can't be null/white/white space");

            if (!ExistsSettingsFile(fileSettingsPath)) throw new InvalidOperationException($"No exists a IsolateStorage settings file {fileSettingsPath} in your IsolateStorage");

            var result = new SettingsInfo();

            var isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileSettingsPath, FileMode.Open, isolatedStorage))
            {
                using (StreamReader reader = new StreamReader(isoStream))
                {
                    string fileContent = reader.ReadToEnd();

                    var parts = fileContent.Split(';');

                    result.ServiceAddress                  = parts[0];
                    result.SecondsVisibilityBallonTime     = int.Parse(parts[1]);
                    result.ShowBallonWithNotificationsOpen = bool.Parse(parts[2]);
                }
            }

            isolatedStorage.Dispose();

            return result;
        }

        public void WriteSettingsFile(string fileSettingsPath, SettingsInfo settingsInfo)
        {
            if (settingsInfo == null) throw new ArgumentNullException(nameof(settingsInfo), $"The parameter {nameof(settingsInfo)} can't be null");

            if (ExistsSettingsFile(fileSettingsPath))
            {
                WriteExistsFile(fileSettingsPath, settingsInfo);
            }
            else
            {
                WriteNewFile(fileSettingsPath, settingsInfo);
            }
        }



        private void WriteNewFile(string fileSettingsPath, SettingsInfo settingsInfo)
        {
            var isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileSettingsPath, FileMode.CreateNew, isolatedStorage))
            {
                using (StreamWriter writer = new StreamWriter(isoStream))
                {
                    writer.WriteLine($"{settingsInfo.ServiceAddress};{settingsInfo.SecondsVisibilityBallonTime};{settingsInfo.ShowBallonWithNotificationsOpen}");
                }
            }

            isolatedStorage.Dispose();
        }

        private void WriteExistsFile(string fileSettingsPath, SettingsInfo settingsInfo)
        {
            //isolatedStorage.Remove();

            //IsolatedStorageFile.Remove(IsolatedStorageScope.User);

            var isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            isolatedStorage.DeleteFile(fileSettingsPath);

            isolatedStorage.Dispose();


            WriteNewFile(fileSettingsPath, settingsInfo);
        }


    }
}