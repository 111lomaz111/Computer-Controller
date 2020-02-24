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
        ObservableCollection<IPAdr> _iPAddresses = new ObservableCollection<IPAdr>();
        public ObservableCollection<IPAdr> IPAddresses { get { return _iPAddresses; } }


        public ConnectPage()
        {
            InitializeComponent();
            _iPAddresses.Add(new IPAdr("127.0.0.1"));

            IpAddressesListView.ItemsSource = IPAddresses;
            GetDevices();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(IpAddressEntry.Text);
            Task.Run(() => CheckApiConnection(ip));
        }


        private void GetDevices()
        {
            for (int i = 0; i < 254; i++)
            {
                Task.Run(async () =>
                {
                    //Console.WriteLine($"{nameof(GetDevices)}/{i}/1");
                    IPAddress ip = IPAddress.Parse($"192.168.1.{i}");
                    var ping = new Ping();
                    byte[] packet = new byte[1];

                    //Console.WriteLine($"{nameof(GetDevices)}/{i}/2");
                    var reply = ping.Send(ip, 100, packet);
                    //Console.WriteLine($"{nameof(GetDevices)}/{i}/3");

                    if (reply.Status == IPStatus.Success)
                    {
                        await CheckApiConnection(reply.Address);
                    }
                });
                Console.WriteLine($"{nameof(GetDevices)}/{i}");
            }
            DisplayAlert("GetDevices", "Endend", "OkeY");
        }

        private async Task CheckApiConnection(IPAddress iPAddress)
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
                        _iPAddresses.Add(new IPAdr(ip));
                    }
                }
            }
            catch (Exception ex) { }

            //var content = await response.Content.ReadAsStringAsync();
            //dynamic aoe = JsonConvert.DeserializeObject<dynamic>(content);
            //
            //await DisplayAlert(response.StatusCode.ToString(), "", "Cancel");
        }


        public class IPAdr
        {
            public string Name { get; set; }

            public IPAdr(string name)
            {
                Name = name;
            }
        }
    }
}