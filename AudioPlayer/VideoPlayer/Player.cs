using Player;
using System;

namespace VideoPlayer
{
    public class Player: BasePlayer<Video>
    {
        public int Speed { get; set; }
              

        public override void Play()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                Console.WriteLine(this.Speed + item.Title);
            }
        }

        public void SwitchSubtitles(bool @switch)
        {
            //Blblblblb
            foreach (var item in Items)
            {
                var subtitles = item.Subtitles;
            }
        }
    }

    public class Video: PlayingItem
    {
        public Video()
        {

        }

        public Video(string bla)
        {

        }

        public override string Title { get; set; }

        public string Subtitles { get; set; }

        public override int Duration { get; set; }
    }
}
