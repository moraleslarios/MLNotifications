using Microsoft.AspNet.SignalR.Client;
using MLNotification.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MLNotification.ServiceClientConnect;

namespace MLNotification.WPClient3
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        private MLMessageHubConect connectHub;

        public MainWindow2()
        {
            InitializeComponent();

            MouseDown += (sender, e) =>
            {
                this.DragMove();
                e.Handled = false;
            };

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connectHub != null) connectHub.Dispose();

                connectHub = BuilderMLMessageHubConnect.CreateMLMessageHub(txtUrl.Text);

                //connectHub.ProcessMessage += (sender2, e2) => lstMensajes.Dispatcher.Invoke(() =>
                //{
                //    lstMensajes.Items.Add(e2.NotificationMessage.Body);
                //}, System.Windows.Threading.DispatcherPriority.Background);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            connectHub.Dispose();

            base.OnClosing(e);
        }

        private async void Storyboard_Completed(object sender, EventArgs e)
        {
            var message = new NotificationMessage { Subject = "App TWO", Body = "The App TWO has finalized on ERROR", User = "App TWO usr", MessageDate = DateTime.Now, Server = "Server Local", UriImage = "https://nhlearningsolutions.com/portals/0/Logos/Win10.png" };

            message.MessageType = MessageType.Error;


            await connectHub.SendMessage(message);
        }
    }
}
