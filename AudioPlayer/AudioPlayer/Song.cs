using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class Song: PlayingItem
    {
        public Song()
        {

        }

        public Song(string bla)
        {

        }

        public override int Duration { get; set; }
        public override string Title { get; set; }
        string Path;
        string Lyries;
        string Genre;

        public Artist Artist;
        Album Album;
    }
}
