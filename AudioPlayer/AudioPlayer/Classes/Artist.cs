namespace AudioPleer
{
    public class Artist
    {
        internal Artist()
        {
            name = "unknow_artist";
            album = new Album();
        }
        internal Artist(string name)
        {
            this.name = name;
        }
        internal Artist(string name,Album album)
        {
            this.name = name;
            this.album = album;
        }
    

        private string name;
        internal string Name { get => name; set => name = value; }


        private Album album;
        internal Album Album { get=>album; set => album = value;}


    }
}
