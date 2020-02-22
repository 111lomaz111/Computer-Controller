using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public static class WebHelper
    {
        public static string GetLocalIPAddressWithPort()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return $"http://{ip}:0";
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
