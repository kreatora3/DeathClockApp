using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace DeathClockApp
{
    class SoundPlayer
    {
        public void PlayMedia(string path)
        {
            if (BackgroundMediaPlayer.Current.CurrentState != MediaPlayerState.Paused)
            {
                BackgroundMediaPlayer.Current.SetUriSource(new Uri(path));
            }
            BackgroundMediaPlayer.Current.Play();

        }
    }
}
