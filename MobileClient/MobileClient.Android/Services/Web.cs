using Java.IO;
using MobileClient.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobileClient.Droid.Services
{
    public class Web : IWeb
    {
        public async Task<List<IPAddress>> Arp_a()
        {
            List<IPAddress> ips = new List<IPAddress>();
            Regex rx = new Regex(@"\b(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))\b");

            PingLocalWeb();

            BufferedReader bf = new BufferedReader(new FileReader("/proc/net/arp")); //allways it will be at least one line //FIXME check user priviliges to access this
            string line = null;
            do
            {
                line = bf.ReadLine();
                if (!string.IsNullOrEmpty(line) && !line.Contains("00:00:00:00:00:00"))
                {
                    MatchCollection m = rx.Matches(line);
                    string s = m.Count.Equals(0) ? null : m[0]?.Value;
                    if (!string.IsNullOrEmpty(s))
                    {
                        IPAddress.TryParse(s, out IPAddress ip);
                        if (ip != null)
                        {
                            ips.Add(ip);
                        }
                    }
                }
            }
            while (line != null);

            return ips;
        }

        private void PingLocalWeb()
        {
            var Client = new UdpClient();
            var RequestData = Encoding.ASCII.GetBytes("SoundController client");
            var ServerEp = new IPEndPoint(IPAddress.Any, 0);
             
            Client.EnableBroadcast = true;
            Client.Send(RequestData, RequestData.Length, new IPEndPoint(IPAddress.Broadcast, 80));

            var ServerResponseData = Client.Receive(ref ServerEp);

            Client.Close();
        }
    }
}