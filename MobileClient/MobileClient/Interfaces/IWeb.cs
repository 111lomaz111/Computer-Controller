using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Interfaces
{
    public interface IWeb
    {
        void Listen(Action<IPAddress> actionOnHit);
        Task<bool> CheckApiConnection(IPAddress iPAddress);

    }
}
