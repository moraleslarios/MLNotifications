using Microsoft.AspNet.SignalR.Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MLNotification.Domain;
using MLNotification.WPFClient.ViewModel;

namespace MLNotification.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NotificationView : Window
    {
        private Storyboard unloadMovie;
        private Storyboard loadMovie;
        private Storyboard unClearAllAnimations;

        private NotificationViewModel viewModel;

        //HubConnection conexionHub = null;
        //IHubProxy proxyHub = null;

        private Border boderTemplate;

        public NotificationView()
        {
            InitializeComponent();

            

            Width = 400;
            //Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Height = System.Windows.SystemParameters.WorkArea.Height;
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;

            unloadMovie          = (Storyboard)Resources["UnLoadAnimation"];
            loadMovie            = (Storyboard)Resources["LoadAnimation"];
            unClearAllAnimations = (Storyboard)Resources["UnClearAllAnimation"];

            viewModel = DataContext as NotificationViewModel;

            AddListBoxScrollEnding();

            DesSelectedListBoxItems();
        }

        private void DesSelectedListBoxItems()
        {
            lstMensajes.SelectionChanged += (sender, e) => lstMensajes.SelectedIndex = -1;
        }

        private void AddListBoxScrollEnding()
        {
            viewModel.Notifications.CollectionChanged += (sender, e) =>
            {
                if (viewModel.Notifications.Any() && lstMensajes.Items.Count > 0)
                {
                    var lastItem = lstMensajes.Items[lstMensajes.Items.Count - 1];
                    lstMensajes.ScrollIntoView(lastItem);
                }
            };
        }


        public void ViewNotifications()
        {
            viewModel.IsViewOpen = true;

            loadMovie.Begin();
        }

        private void window_Activated(object sender, EventArgs e)
        {
            //loadMovie.Begin();
        }

        private void window_Deactivated(object sender, EventArgs e)
        {
            //unloadMovie.Completed += (sender2, e2) => Visibility = Visibility.Collapsed;

            ////System.Threading.Thread.Sleep(5000);

            //unloadMovie.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            unloadMovie.Completed += (sender2, e2) =>
            {
                Visibility = Visibility.Collapsed;
                viewModel.IsViewOpen = false;
            };

            //System.Threading.Thread.Sleep(5000);

            unloadMovie.Begin();
        }

        private void Bd_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            boderTemplate = (Border)e.OriginalSource;
        }








        private async void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //boderTemplate.MaxWidth = 2000;

            var rowContext = ((FrameworkElement)e.OriginalSource).DataContext as NotificationMessage;

            await Task.Delay(500);

            viewModel.DeletedNotification(rowContext);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {

        }

        private void ClearAllAnimation_Completed(object sender, EventArgs e)
        {
            viewModel.DeletedAllNotification();

            unClearAllAnimations.Begin();
        }
    }
}
