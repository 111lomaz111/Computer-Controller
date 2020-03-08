using MobileClient.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectPage : ContentPage
    {

        private IWeb _webService => DependencyService.Get<IWeb>();

        ObservableCollection<IPAdr> _iPAddresses = new ObservableCollection<IPAdr>();
        public ObservableCollection<IPAdr> IPAddresses { get { return _iPAddresses; } }


        public ConnectPage()
        {
            InitializeComponent();
            IpAddressesListView.ItemsSource = IPAddresses;
            ShowLoadingIndicator(false);
        }

        private async Task<bool> CheckApiConnection(IPAddress iPAddress)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"http://{iPAddress}/Api/Sound/CheckConnection");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string ip = iPAddress.ToString();
                    if (!_iPAddresses.Any(x => x.Name == ip))
                    {
                        //_iPAddresses.Add(new IPAdr(ip));
                        return true;
                    }
                }
            }
            catch (Exception ex) { }

            return false;
        }

        public class IPAdr
        {
            public string Name { get; set; }

            public IPAdr(string name)
            {
                Name = name;
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Task.Run(() => SearchDevices());
        }

        private async void SearchDevices()
        {
            ShowLoadingIndicator(true);

            _iPAddresses.Clear();

            var ips = await _webService.Arp_a();

            ips.ToList().ForEach(x =>
            {
                if (CheckApiConnection(x).Result)
                {
                    _iPAddresses.Add(new IPAdr(x.ToString()));
                }
            });

            ShowLoadingIndicator(false);
        }

        private void ShowLoadingIndicator(bool isEnable)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                listIndicator.IsVisible = isEnable;
                listIndicator.IsRunning = isEnable;
            });
        }
    }
}