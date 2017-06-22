using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MLNotification.Domain;
using System.Windows.Media;

namespace MLNotification.WPFClient.Converters
{
    public class StateBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MessageType messagType = (MessageType)value;

            SolidColorBrush result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#F22B2A2A"));

            switch (messagType)
            {
                case MessageType.Information:
                case MessageType.Warnnig:
                case MessageType.Error:
                case MessageType.VeryImportant:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#F22B2A2A"));
                    break;
                case MessageType.Information_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF242E38"));
                    break;
                case MessageType.Warnnig_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF292714"));
                    break;
                case MessageType.Error_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF291414"));
                    break;
                case MessageType.VeryImportant_urgent:
                    result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF151D11"));
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
