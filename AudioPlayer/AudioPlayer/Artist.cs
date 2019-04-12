using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Artist
    {
        public string Name;
        public Artist() {
            this.Name = "unknown_artist";
        }

        public Artist(string name) {
            this.Name = name;
        }
    }
}
