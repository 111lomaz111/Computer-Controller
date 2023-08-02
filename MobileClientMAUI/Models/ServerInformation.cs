using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MobileClient.Models
{
    public class ServerInformation
    {
        public string Name { get; set; }
        public IPAddress IPAddress { get; set; }

        public ServerInformation(string name)
        {
            Name = name;
        }
        public ServerInformation(string name, IPAddress ipAddress)
        {
            Name = name;
            IPAddress = ipAddress;
        }
    }
}
