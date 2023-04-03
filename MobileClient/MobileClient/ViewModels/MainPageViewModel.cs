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
        public ServerInformation SelectedServer { get; set; }

        public ICommand SearchServersCommand { get; }
        private IWeb _webService => DependencyService.Get<IWeb>();


        public MainPageViewModel()
        {
            SearchServersCommand = new Command(SearchDevices);
        }


        internal void SearchDevices()
        {
            IsBusy = true;

            _webService.Listen((x) =>
            {
                
                if (Servers.Where(y => y.IPAddress == x).Count() == 0 && _webService.CheckApiConnection(x).Result)
                {
                    Servers.Add(new ServerInformation(x.MapToIPv4().ToString()));
                }
            });

            IsBusy = false;
        }
    }
}
