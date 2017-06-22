using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MLNotification.WPFClient.ViewModel;

namespace MLNotification.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);

            var notificationViewModel = (NotificationViewModel) App.Current.Windows.OfType<NotificationView>().FirstOrDefault().DataContext;
            notificationViewModel.IsConnected = false;


            e.Handled = true;
        }
    }
}
