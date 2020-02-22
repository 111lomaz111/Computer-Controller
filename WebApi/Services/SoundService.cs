using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Consts;

namespace WebApi.Services
{
    public class SoundService : ISoundService
    {
        private CoreAudioDevice _defaultPlaybackDevice;


        public SoundService()
        {
            _defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        }

        public bool Mute()
        {
            _defaultPlaybackDevice.Mute(!_defaultPlaybackDevice.IsMuted);
            return _defaultPlaybackDevice.IsMuted;
        }

        public int VolumeUp()
        {
            return AddVolumeLevel(SoundConsts.VolumeChange);
        }

        public int VolumeDown()
        {
            return AddVolumeLevel(-SoundConsts.VolumeChange); 
        }


        private int AddVolumeLevel(int value)
        {
            _defaultPlaybackDevice.Volume += value;

            return (int)_defaultPlaybackDevice.Volume;
        }
    }
}
