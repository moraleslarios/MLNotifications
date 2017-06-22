using MLNotification.WPFClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MLNotification.WPFClient
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel         mainViewModel;
        private NotificationViewModel notificationViewModel;



        private Storyboard tryToolTipImageAnimation;

        public MainView()
        {
            InitializeComponent();

            mainViewModel = DataContext as MainViewModel;
            notificationViewModel = mainViewModel.notificationViewModel;

            tryToolTipImageAnimation = (Storyboard)Resources["TryToolTipImageAnimation"];

            SuscriveToHideAddNotifications();
        }

        private void SuscriveToHideAddNotifications()
        {
            notificationViewModel.AddMessageHide += (sender, e) =>
            {
                MLBallon mlBallon = new MLBallon();

                mlBallon.DataContext = e.NotificationMessage;

                int miliseconds =  Settings.SettingsBuilder.BuildSettings().ReadSettings().SecondsVisibilityBallonTime * 1000;

                tbTaskBarIcon.ShowCustomBalloon(mlBallon, System.Windows.Controls.Primitives.PopupAnimation.Slide, miliseconds);
            };
        }

        private void TaskbarIcon_TrayToolTipOpen(object sender, RoutedEventArgs e)
        {
            tryToolTipImageAnimation.Begin();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
