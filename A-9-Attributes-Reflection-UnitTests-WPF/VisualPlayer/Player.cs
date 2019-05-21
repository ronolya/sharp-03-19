using System;
using System.IO;
using System.Linq;
using System.Media;

namespace VisualPlayer
{
    public class Player
    {
        public Song[] Songs { get; private set; }
        public SoundPlayer player = new System.Media.SoundPlayer()

        public int Volume { get; set; }

        public void VolumeUp()
        {
            Volume++;
        }

        public void VolumeDown()
        {
            Volume--;
        }

        public void Load(string folder)
        {
            var files = Directory.GetFiles(folder, "*.wav");
            Songs = files
                .Select(path => new FileInfo(path))
                .Select(fi => new Song()
                {
                    Title = fi.Name.Replace(".wav", ""),
                    Path = fi.FullName
                }).ToArray();
        }
    }

    public class Song
    {
       public string Title { get; set; }
       public string Path { get; set; }
    }
}
