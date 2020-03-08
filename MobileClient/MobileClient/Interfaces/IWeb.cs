using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Interfaces
{
    public interface IWeb
    {
        Task<List<IPAddress>> Arp_a();
    }
}
