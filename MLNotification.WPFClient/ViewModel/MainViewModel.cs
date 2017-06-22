using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Linq;
using System;

namespace MLNotification.WPFClient.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        private NotificationView      viewNotifications;
        public  NotificationViewModel notificationViewModel;

        public MainViewModel()
        {
            viewNotifications     = new NotificationView();
            notificationViewModel = viewNotifications.DataContext as NotificationViewModel;

            GetNotificationsCountRegister();
        }



        private int _motificationsCount = 0;
        public int NotificationsCount
        {
            get => _motificationsCount;
            set => Set(nameof(NotificationsCount), ref _motificationsCount, value);
        }




        public RelayCommand OpenNotificationsCommand
        {
            get => new RelayCommand(OpenNotifications);
        }

        public RelayCommand OpenSettingsViewCommand
        {
            get => new RelayCommand(() => new SettingsView().ShowDialog());
        }



        private void OpenNotifications()
        {
            if (viewNotifications.Visibility != Visibility.Visible)
            {
                viewNotifications.ViewNotifications();
            }
        }


        private void GetNotificationsCountRegister()
        {
            notificationViewModel.Notifications.CollectionChanged += (sender, e) => NotificationsCount = notificationViewModel.Notifications?.Count ?? 0;
        }



    }
}