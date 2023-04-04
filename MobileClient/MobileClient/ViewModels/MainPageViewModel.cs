using MobileClient.API;
using MobileClient.Interfaces;
using MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<ServerInformation> Servers { get; internal set; } = new ObservableCollection<ServerInformation>();
        private ServerInformation _selectedServer;
        public ServerInformation SelectedServer { 
            get => _selectedServer;
            set => SetProperty(
                ref _selectedServer, 
                value, 
                onChanged: () => {
                   _restClient.SetBaseAddress(SelectedServer);
                });
        }

        public int _currentVolumeLevel;
        public int CurrentVolumeLevel { 
            get => _currentVolumeLevel;
            set => SetProperty(ref _currentVolumeLevel, value, onChanged: () => ChangeVolumeByValue(value));
        }

        public ICommand SearchServersCommand { get; }
        public ICommand ChangeVolumeCommand { get; }
        
        private IWeb _webService => DependencyService.Get<IWeb>();
        private IRestCommands _restClient => DependencyService.Get<IRestCommands>();


        public MainPageViewModel()
        {
            SearchServersCommand = new Command(SearchDevices);
            ChangeVolumeCommand = new Command(ChangeValueByButtons);
        }

        private void ChangeValueByButtons(object volumeAmount)
        {
            CurrentVolumeLevel += Convert.ToInt32(volumeAmount);
        }

        private void ChangeVolumeByValue(int volumeAmount)
        {
            _restClient.ChangeVolumeByValue(volumeAmount);
        }

        internal void SearchDevices()
        {
            IsBusy = true;

            _webService.Listen((x) =>
            {
                if (Servers.Where(y => y.IPAddress == x).Count() == 0 && _webService.CheckApiConnection(x).Result)
                {
                    Servers.Add(new ServerInformation(x.MapToIPv4().ToString(), x));
                }
            });

            IsBusy = false;
        }
    }
}
