using MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.API
{
    internal interface IRestCommands
    {
        void SetBaseAddress(ServerInformation si);
        bool ChangeVolumeByValue(int volumeToSet);
        bool ChangeMuteState();
    }
}