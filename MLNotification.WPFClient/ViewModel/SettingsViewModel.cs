using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLNotification.WPFClient.Settings;
using MLNotification.ServiceClientConnect;

namespace MLNotification.WPFClient.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {

        private ISettingsManager settingsManager;

        public event EventHandler SavedSettings;

        public SettingsViewModel(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;

            LoadData();
        }


        private SettingsInfo _model;
        public SettingsInfo Model
        {
            get => _model;
            set => Set(nameof(Model), ref _model, value);
        }



        private string _serviceAddress;
        public string ServiceAddress
        {
            get => _serviceAddress;
            set => Set(nameof(ServiceAddress), ref _serviceAddress, value);
        }

        private int _secondsVisibilityBallonTime;
        public int SecondsVisibilityBallonTime
        {
            get => _secondsVisibilityBallonTime;
            set => Set(nameof(SecondsVisibilityBallonTime), ref _secondsVisibilityBallonTime, value);
        }

        private bool _showBallonWithNotificationsOpen;
        public bool ShowBallonWithNotificationsOpen
        {
            get => _showBallonWithNotificationsOpen;
            set => Set(nameof(ShowBallonWithNotificationsOpen), ref _showBallonWithNotificationsOpen, value);
        }


        public RelayCommand SaveSettingsCommand
        {
            get => new RelayCommand(SaveSettings);
        }

        private void SaveSettings()
        {
            SettingsInfo settingsInfo = new SettingsInfo
            {
                ServiceAddress = ServiceAddress,
                SecondsVisibilityBallonTime = SecondsVisibilityBallonTime,
                ShowBallonWithNotificationsOpen = ShowBallonWithNotificationsOpen
            };

            settingsManager.WriteSettings(settingsInfo);

            Reconect(ServiceAddress);

            OnSavedSettings();
        }

        private void Reconect(string serviceAddress)
        {
            var notificationView = App.Current.Windows.OfType<NotificationView>().FirstOrDefault();

            if(notificationView != null)
            {
                var connectHub = BuilderMLMessageHubConnect.CreateMLMessageHub(serviceAddress);
                notificationView.DataContext = new NotificationViewModel(connectHub) { IsConnected = true };
                var notificationViewModel = (NotificationViewModel)notificationView.DataContext;
                notificationViewModel.DeletedAllNotification();

            }
        }

        private void LoadData()
        {
            Model = settingsManager.ReadSettings();

            ServiceAddress                  = Model.ServiceAddress;
            SecondsVisibilityBallonTime     = Model.SecondsVisibilityBallonTime;
            ShowBallonWithNotificationsOpen = Model.ShowBallonWithNotificationsOpen;
        }

        protected virtual void OnSavedSettings() => SavedSettings?.Invoke(this, new EventArgs());
    }
}
