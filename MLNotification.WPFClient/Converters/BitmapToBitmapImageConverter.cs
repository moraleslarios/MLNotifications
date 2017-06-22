using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace MLNotification.WPFClient.Converters
{
    public class BitmapToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //var rd = new ResourceDictionary();
            //rd.Source = new Uri("MLNotification.WPFClient:///MLDarkStyle.xaml");

            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                //BitmapImage logo = new BitmapImage();
                //logo.BeginInit();
                //string path = @"/MLNotification.WPFClient;component/Images/information.png";
                //logo.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                //logo.EndInit();


                ////result.BeginInit();
                ////result.UriSource = new Uri(@"/MLNotification.WPFClient;component/Images/information.png", UriKind.Relative);
                ////result.EndInit();

                //return new ImageBrush(logo);

                var imageBrush = (ImageBrush)Application.Current.Resources["SettingsLogoPrincipalBrush"];

                return imageBrush;
            }

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            string path = value.ToString();
            logo.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            logo.EndInit();

            var result = new ImageBrush (logo);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }



        private BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

    }
}
