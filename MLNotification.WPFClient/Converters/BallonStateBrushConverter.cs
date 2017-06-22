using MLNotification.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MLNotification.Domain;
using System.Windows.Media;
using System.Globalization;

namespace MLNotification.WPFClient.Converters
{
    public class BallonStateBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MessageType messagType = (MessageType)value;

            SolidColorBrush result = Brushes.Transparent;

            switch (messagType)
            {
                case MessageType.Information:
                case MessageType.Warnnig:
                case MessageType.Error:
                case MessageType.VeryImportant:
                    result = Brushes.White;
                    break;
                case MessageType.Information_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF87A4AA"));
                    break;
                case MessageType.Warnnig_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA8AA87"));
                    break;
                case MessageType.Error_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFAA878C"));
                    break;
                case MessageType.VeryImportant_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF94AA87"));
                    break;
                default:
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
