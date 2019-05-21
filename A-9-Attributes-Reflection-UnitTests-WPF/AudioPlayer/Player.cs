using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class Player
    {
        public Song[] Songs { get; private set; }
        public Song PlayingSong { get; private set; }

        private SoundPlayer player = new SoundPlayer();
        private bool playing = false;

        public event Action VolumeChanged;
        public event Action PlayStart;
        public event Action PlayEnd;
        public event Action SongStart;

        public int Volume { get; set; }

        public void VolumeUp()
        {
            Volume++;
            VolumeChanged?.Invoke();
        }

        public void VolumeDown()
        {
            Volume--;
            VolumeChanged?.Invoke();
        }

        public async void Play()
        {
            if (Songs.Length == 0)
                return;

            PlayingSong = PlayingSong ?? Songs[0];
            playing = true;

            PlayStart?.Invoke();

            var index = Array.IndexOf(Songs, PlayingSong);

            while (playing)
            {
                SongStart?.Invoke();

                await Task.Run(() =>
                {
                    player.SoundLocation = PlayingSong.Path;
                    player.PlaySync();
                });

                index++;
                PlayingSong = Songs[index % (Songs.Length - 1)];
            }
        }

        public void Stop()
        {
            playing = false;
            player.Stop();

            PlayStart?.Invoke();
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
