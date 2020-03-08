using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public static class WebHelper
    {
        private const int _listenPort = 80;
        private static string _ipAdrress;
        public static string GetWebAPIListenAddress()
        {
            if (!string.IsNullOrEmpty(_ipAdrress))
            {
                return _ipAdrress;
            }
            else
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var _ip in host.AddressList)
                {
                    if (_ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        _ipAdrress = $"http://{_ip}:{_listenPort}";
                        Task.Run(() => BroadcastServer());
                        return GetWebAPIListenAddress();
                    }
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
        }

        public static Task BroadcastServer()
        {
            var Server = new UdpClient(_listenPort);
            var ResponseData = Encoding.ASCII.GetBytes("SoundController server");

            while (true)
            {
                var ClientEp = new IPEndPoint(IPAddress.Any, 0);
                var ClientRequestData = Server.Receive(ref ClientEp);
                var ClientRequest = Encoding.ASCII.GetString(ClientRequestData);

                Console.WriteLine("Recived {0} from {1}, sending response", ClientRequest, ClientEp.Address.ToString());
                Server.Send(ResponseData, ResponseData.Length, ClientEp);
            }
        }
    }
}
