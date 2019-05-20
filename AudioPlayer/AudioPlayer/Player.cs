using Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AudioPlayer
{
    public class APlayer: BasePlayer<Song>
    {
        public override void Play()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine(Items[i].Title + " " + Items[i].Artist.Name + " " + Items[i].Duration);
                System.Threading.Thread.Sleep(Items[i].Duration);
            }
        }
    }
}
