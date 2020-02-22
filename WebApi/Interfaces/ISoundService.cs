using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface ISoundService
    {
        /// <summary>
        /// Reversing current state of mute.
        /// </summary>
        /// <returns>Bool state if system is muted</returns>
        public bool Mute();
        /// <summary>
        /// Making volume value bigger by 1 percent point.
        /// </summary>
        /// <returns>Current volume loudness in percent points.</returns>
        public int VolumeUp();
        /// <summary>
        /// Making volume value smaller by 1 percent point.
        /// </summary>
        /// <returns>Current volume loudness in percent points.</returns>
        public int VolumeDown();
    }
}
