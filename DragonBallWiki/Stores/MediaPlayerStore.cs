using DragonBallWiki.Util;
using System;
using System.Windows.Media;

namespace DragonBallWiki.Stores
{
    public class MediaPlayerStore
    {
        private static MediaPlayer _player;


        public static MediaPlayer GetPlayer ()
        {
            if (_player is not null) return _player;
            throw new Exception("Error: player wasn't initialized!");
        }


        public static void InitializePlayer ()
        {
            if (_player is null)
            {
                _player = new()
                {
                    Volume = 0.1,
                };

                _player.MediaEnded += PlayerMediaEnded;
                _player.Open(ResourcePaths.RandomBGM());
            }
        }


        private static void PlayerMediaEnded (object sender, EventArgs e)
        {
            _player.Close();
            _player.Open(ResourcePaths.RandomBGM());
            _player.Play();
        }
    }
}
