using System;

namespace DragonBallWiki.Util
{
    class ResourcePaths
    {
        public static readonly string BASEPATH = $"{AppDomain.CurrentDomain.BaseDirectory}/../../../..";
        //public static readonly Uri LOGO_SVG = new($"{BASEPATH}/Resources/Images/logo.svg");
        public static readonly string BGM = $"{BASEPATH}/Resources/Sounds/bgm_X.wav";


        private static readonly int _maxBGM = 2;
        private static int _lastBGM = 0;


        public static Uri RandomBGM ()
        {
            var r = new Random();
            var number = r.Next(1, _maxBGM + 1);

            while (number == _lastBGM)
            {
                number = r.Next(1, _maxBGM + 1);
            }

            _lastBGM = number;

            var bgm = BGM.Split('X');
            var bgmNumber = number.ToString().Length > 1 ? number.ToString() : $"0{number}";
            return new($"{bgm[0]}{bgmNumber}{bgm[1]}");
        }
    }
}
