using MLNotification.WPFClient.Settings;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace MLNotification.WPFClient.Tests.Settings
{
    public class SettingsManagerTests
    {

        private ISettingsManager instance;

        private IFileSettingsManager fileSettingsManager;


        public SettingsManagerTests()
        {
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            fileSettingsManager = new IsolateFileManager(isolatedStorage);

            instance = new SettingsManager(fileSettingsManager);
        }



    }
}
