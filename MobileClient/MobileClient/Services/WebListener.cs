using MobileClient.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Services
{
    public class WebListener : IWeb
    {
        public static readonly int SERVER_PORT = 1337;

        public void Listen(Action<IPAddress> actionOnHit)
        {
            Listener(actionOnHit);
        }

        private Task Listener(Action<IPAddress> actionOnHit)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, SERVER_PORT));

            var from = new IPEndPoint(0, 0);
            var task = Task.Run(() =>
            {
                while (true)
                {
                    var recvBuffer = udpClient.Receive(ref from);

                    string receiveMessage = Encoding.UTF8.GetString(recvBuffer);
                    string ipAddresss = from.Address.MapToIPv4().ToString();

                    Console.WriteLine($"From: {ipAddresss}; Message {receiveMessage}");
                    actionOnHit?.Invoke(from.Address);
                }
            });

            var data = Encoding.UTF8.GetBytes("Hello SoundController");
            udpClient.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, SERVER_PORT));
            
            return Task.FromResult<object>(null);
        }
        public async Task<bool> CheckApiConnection(IPAddress iPAddress)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"http://{iPAddress}:{SERVER_PORT}/Api/Sound/CheckConnection");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            return false;
        }
    }
}
