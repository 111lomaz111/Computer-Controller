using MobileClient.API;
using MobileClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobileClient.Services
{
    internal class RestClientService : IRestCommands
    {
        HttpClient _client;

        public RestClientService()
        {
            _client = new HttpClient();
        }

        private StringContent BakeContent(object content)
        {
            string jsonArgs = JsonConvert.SerializeObject(content);

            StringContent stringContent = new StringContent(jsonArgs, Encoding.UTF8, "application/json");
            return stringContent;
        }

        public void SetBaseAddress(ServerInformation si)
        {
            _client.BaseAddress = new Uri($"http://{si.IPAddress.ToString()}:{Constants.Server.LISTENING_PORT}/API/Sound/");
        }

        public bool ChangeVolumeByValue(int value)
        {
            var response = _client.PutAsync($"ChangeVolumeByValue/{value}",null);

            return response.Result.IsSuccessStatusCode;
        }

        public bool ChangeMuteState()
        {
            var response = _client.PutAsync("Mute",null);

            return response.Result.IsSuccessStatusCode;
        }
    }
}
