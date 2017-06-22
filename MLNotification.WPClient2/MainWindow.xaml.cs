using MahApps.Metro.Controls;
using MLNotification.Domain;
using MLNotification.ServiceClientConnect;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace MLNotification.WPClient2
{

    public partial class MainWindow : MetroWindow
    {

        private MLMessageHubConect connectHub;



        public MainWindow()
        {
            InitializeComponent();

            this.AllowsTransparency = true;

            /// enabled drag and drop the window
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

                connectHub.ProcessMessage += (sender2, e2) => lstServerMessages.Dispatcher.Invoke(() =>
                {
                    lstServerMessages.Items.Add(e2.NotificationMessage.Body);
                }, System.Windows.Threading.DispatcherPriority.Background);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        async private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var message = new NotificationMessage
            {
                Subject     = txtSubject.Text,
                Body        = txtMensaje.Text,
                User        = txtUser.Text,
                MessageDate = DateTime.Now,
                Server      = txtServer.Text,
                UriImage    = txtUriImage.Text
            };

            message.MessageType = (MessageType)cmbType.SelectedIndex;

            await connectHub.SendMessage(message);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            connectHub.Dispose();

            base.OnClosing(e);
        }


        private void ButtonClose_Click(object sender, RoutedEventArgs e) => Close();

        private void txtUriImage_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUriImage?.Text)) return;

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                string path = txtUriImage.Text;
                logo.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                logo.EndInit();

                var img = new ImageBrush(logo);

                bdImage.Background = img;
            }
            catch (Exception)
            {
                // nothing
            }
        }
    }


}
