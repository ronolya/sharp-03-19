using System;

namespace AudioPleer
{

    public class Song : IComparable
    {
        #region Properts
        private bool ? like;
        private bool ? dislike;
        private int duration;
        private string title;
        private string path;
        private string lyries;
        private string genry;
        private Artist artist;
        private Album album;

        public void Deconstruct(out string title, out Artist artist, out string lyries, out string genry, out bool ? like, out bool ? dislike)
        {
            title = this.title;
            artist = this.artist;
            lyries = this.lyries;
            genry = this.genry;
            like  =  this.like;
            dislike = this.dislike;
        }

        public bool Like
        {
            get
            {
                if (!like.HasValue)
                    like  = false;

                return like.Value;
            }
                
            set => like = value;
        }
        public bool Dislike
        {
            get
            {
                if (!dislike.HasValue)
                    dislike= false;

                return dislike.Value;
            }

            set => dislike = value;
        }
        public int Duration { get => duration; set => duration = value; }
        public string Title { get => title; set => title = value; }
        public string Path { get => path; set => path = value; }
        public string Lyries { get => lyries; set => lyries = value; }
 
        public string Genry { get => genry; set => genry = value; }

        public Artist Artist { get => artist; set => artist = value; }
        public Album Album { get => album; set => album = value; }

        #endregion

        public int CompareTo(object obj)
        {
            Song song = obj as Song;
            if (song != null)
            {
                return Title.CompareTo(song.title);
            }
            else throw new NotImplementedException();
        }

       
    }
}
