using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MLNotification.Domain;
using MLNotification.ServiceClientConnect;
using System.Windows;
using MLNotification.ServiceClientConnect.EventArgs;
using GalaSoft.MvvmLight.CommandWpf;

namespace MLNotification.WPFClient.ViewModel
{
    public class NotificationViewModel : ViewModelBase
    {
        private readonly IMLMessageHubConect connectHub;


        public event EventHandler<MLMessageEventArgs> AddMessageHide;


        private ObservableCollection<NotificationMessage> _notifications;
        public ObservableCollection<NotificationMessage> Notifications
        {
            get => _notifications; 
            set => Set(nameof(Notifications), ref _notifications, value); 
        }


        private bool _isViewOpen = false;
        public bool IsViewOpen
        {
            get => _isViewOpen;
            set => Set(nameof(IsViewOpen), ref _isViewOpen, value);
        }

        private bool _isConnected = true;
        public bool IsConnected
        {
            get => _isConnected;
            set => Set(nameof(IsConnected), ref _isConnected, value);
        }


        public RelayCommand OpenSettingsViewCommand
        {
            get => new RelayCommand(() => new SettingsView().ShowDialog());
        }



        public void DeletedNotification(NotificationMessage item)
        {
            Notifications.Remove(item);
        }


        public void DeletedAllNotification()
        {
            Notifications.Clear();
        }







        public NotificationViewModel(IMLMessageHubConect connectHub)
        {
            Notifications = new ObservableCollection<NotificationMessage>();

            this.connectHub = connectHub;

            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            

            connectHub.ProcessMessage += (sender, e) =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Notifications.Add(e.NotificationMessage);

                    var showBallon = Settings.SettingsBuilder.BuildSettings().ReadSettings().ShowBallonWithNotificationsOpen;

                    if(showBallon)
                    {
                        OnAddMessageHide(e.NotificationMessage);
                    }
                    else
                    {
                        if(! IsViewOpen) OnAddMessageHide(e.NotificationMessage);
                    }
                });

            };
        }



        protected virtual void OnAddMessageHide(NotificationMessage message) => AddMessageHide?.Invoke(this, new MLMessageEventArgs(message));


    }
}
