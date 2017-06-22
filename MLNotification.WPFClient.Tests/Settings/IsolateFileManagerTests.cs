using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MLNotification.WPFClient.Settings;
using System.IO.IsolatedStorage;

namespace MLNotification.WPFClient.Tests.Settings
{
    public class IsolateFileManagerTests
    {

        private IFileSettingsManager instance;

        private IsolatedStorageFile isolateFile;


        public IsolateFileManagerTests()
        {
            isolateFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            instance = new IsolateFileManager(isolatedStorage: isolateFile);
        }



        //[Fact]

        //public void ExistsSettingsFile_Exists_OK()
        //{
        //    string fileSettingsPath = SettingsGlobalData.PathFileSettingsName;

        //    bool result = instance.ExistsSettingsFile(fileSettingsPath);

        //    Assert.True(result);
        //}

        //[Fact]
        //public void ExistsSettingsFile_NotExists_OK()
        //{
        //    string fileSettingsPath = SettingsGlobalData.PathFileSettingsName + "aaa";

        //    bool result = instance.ExistsSettingsFile(fileSettingsPath);

        //    Assert.False(result);
        //}

        //[Fact]
        //public void WriteSettingsFile_Real_NotExists_OK()
        //{
        //    string fileSettingsPath = SettingsGlobalData.PathFileSettingsName;

        //    SettingsInfo settingsInfo = new SettingsInfo
        //    {
        //        ServiceAddress                  = "http://localhost:1111",
        //        SecondsVisibilityBallonTime     = 4,
        //        ShowBallonWithNotificationsOpen = true
        //    };

        //    instance.WriteSettingsFile(fileSettingsPath, settingsInfo);
        //}


        [Fact]
        public void WriteSettingsFile_Real_Exists_OK()
        {
            string fileSettingsPath = SettingsGlobalData.PathFileSettingsName;

            SettingsInfo settingsInfo = new SettingsInfo
            {
                ServiceAddress = "http://localhost:9999",
                SecondsVisibilityBallonTime = 10,
                ShowBallonWithNotificationsOpen = false
            };

            instance.WriteSettingsFile(fileSettingsPath, settingsInfo);
        }

        //[Fact]
        //public void ReadSettingsFile_Real_Exists_OK()
        //{
        //    string fileSettingsPath = SettingsGlobalData.PathFileSettingsName;

        //    SettingsInfo settingsInfo = instance.ReadSettingsFile(fileSettingsPath);

        //    Assert.NotNull(settingsInfo);
        //}




    }
}
