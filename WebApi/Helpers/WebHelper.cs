using System;
using System.Net;
using System.Net.Sockets;

namespace WebApi.Helpers
{
    public static class WebHelper
    {
        public static string GetWebAPIListenAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return $"http://{ip}:80";
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
