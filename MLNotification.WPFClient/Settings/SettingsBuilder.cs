using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotification.WPFClient.Settings
{
    public class SettingsBuilder
    {


        public static ISettingsManager BuildSettings()
        {
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            IFileSettingsManager fileSettingsManager = new IsolateFileManager(isolatedStorage);

            ISettingsManager result = new SettingsManager(fileSettingsManager);

            return result;
        }


    }
}
