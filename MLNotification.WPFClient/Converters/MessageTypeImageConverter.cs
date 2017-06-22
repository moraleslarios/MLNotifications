using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MLNotification.Domain;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace MLNotification.WPFClient.Converters
{
    public class MessageTypeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueData = value ?? 0;

            var dataType = (MessageType)valueData;

            string path = string.Empty;

            switch (dataType)
            {
                case MessageType.Information:
                case MessageType.Information_urgent:
                    path = @"/MLNotification.WPFClient;component/Images/information.png";
                    break;
                case MessageType.Warnnig:
                case MessageType.Warnnig_urgent:
                    path = @"/MLNotification.WPFClient;component/Images/warining.png";
                    break;
                case MessageType.Error:
                case MessageType.Error_urgent:
                    path = @"/MLNotification.WPFClient;component/Images/error.png";
                    break;
                case MessageType.VeryImportant:
                case MessageType.VeryImportant_urgent:
                    path = @"/MLNotification.WPFClient;component/Images/veryimportant.png";
                    break;
                default:

                    break;
            }

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(path, UriKind.Relative);
            logo.EndInit();

            return logo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
