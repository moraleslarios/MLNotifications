using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MLNotification.WPFClient.Converters
{
    public class NotConectedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = bool.Parse(value?.ToString() ?? "false");

            string result = null;

            if (boolValue)
            {
                result = "MLNotifications";
            }
            else
            {
                result = "Not Conected";
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}