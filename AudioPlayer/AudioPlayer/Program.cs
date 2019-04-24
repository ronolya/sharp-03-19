using AudioPleyr;
using System;
using System.Diagnostics;
using System.Threading;
using AudioPlayer.Classes;

namespace AudioPleer
{
    class Program
    {
        [Flags]
        public enum LyriesEnum
        {
            Folk,
            Country,
            Latin,
            Blues,
            Rhythm,
            Jazz
        }

        #region Method
        public static Artist AddArtist()
        {
            Artist artist = new Artist();

            return artist;
        }
        public static Artist AddArtist(string artistName, string nameAlbum)
        {
            Artist artist = new Artist();
            artist.Name = artistName;
            artist.Album.Name = nameAlbum;

            return artist;
        }
        public static Artist AddArtist(string artistName, string nameAlbum, int ageAlbum)
        {
            Artist artist = new Artist();
            artist.Name = artistName;
            artist.Album.Name = nameAlbum;
            artist.Album.Age = ageAlbum;

            return artist;
        }

        public static Song CreateSongs()
        {
            Random random = new Random();
            var song = new Song();
            song.Title = "Дыр сигарет с ментолом";
            song.Duration = random.Next(150, 500);
            song.Artist = AddArtist();

            return song;
        }

        public static Song CreateSongs(string nameSong, string nameAlbum, string artName)
        {

            Random random = new Random();
            var song = new Song();
            song.Title = nameSong;
            song.Duration = random.Next(150, 500);
            song.Artist = AddArtist(artName, nameAlbum);

            return song;
        }
        public static Song CreateSongs(string nameSong, int duration, string artist, string nameAlbum, int ageAlbum, string liric)
        {

            var song = new Song();
            song.Title = nameSong;
            song.Duration = duration;
            song.Artist = AddArtist(nameAlbum: nameAlbum, artistName: artist, ageAlbum: ageAlbum);
            song.Lyries = liric;

            return song;
        }
        #endregion

        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            var player = new Player();
            var thread = new Thread(() =>
            {
                player.Play();

            });

            FileManager manager = new FileManager();

            if (manager.IsExistFile())
                player.DeserializeJson();

            while (true)
            {
                Console.Write("Action:");

                switch (Console.ReadLine().ToLower())
                {
                    case "play":
                      
                         thread.Start();
                       
                        break;

                    case "stop":
                        thread.Abort();
                        break;

                    case "sort":
                        player.SortByTitle();                        
                        break;

                    case "random":
                        player.Shuffle();
                        break;

                    case "volume":
                        Console.Write("set volume=");

                        int volume;
                        bool isNumeric = int.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out volume);

                        if (isNumeric)
                            player.Volume = volume;

                        break;

                    case "like":
                        player.Like();
                        break;

                    case "dislike":
                        player.Dislike();
                        break;

                    // вывидет на экран все песни с этим жанром 
                    case "filter":
                        player.FilterByGenre(LyriesEnum.Latin);
                        break;

                    case "exit":
                        Process.GetCurrentProcess().Kill();
                        break;

                    case "addsong":

                        string tempLirica = ((int)LyriesEnum.Blues | (int)LyriesEnum.Folk).ToString();
                        var song1 = CreateSongs("A me Touch Your Fire", 30, "A R I Z O N A", "Album1", 2018, tempLirica);

                        tempLirica = ((int)LyriesEnum.Latin).ToString();
                        var song2 = CreateSongs("B me Touch Your Fire", 30, "A R I Z O N A", "Album1", 2018, tempLirica);

                        tempLirica = ((int)LyriesEnum.Country | (int)LyriesEnum.Jazz).ToString();
                        var song3 = CreateSongs("C me Touch Your Fire", 30, "A R I Z O N A", "Album1", 2018, tempLirica);

                        tempLirica = ((int)LyriesEnum.Country | (int)LyriesEnum.Jazz).ToString();
                        var song4 = CreateSongs("D me Touch Your Fire", 30, "A R I Z O N A", "Album1", 2018, tempLirica);

                        tempLirica = ((int)LyriesEnum.Country | (int)LyriesEnum.Jazz).ToString();
                        var song5 = CreateSongs("Z me Touch Your Fire", 30, "A R I Z O N A", "Album1", 2018, tempLirica);

                        player.PlayAdd(song1, song2, song3,song4,song5);

                        player.Shuffle();

                        var str = player.SerializeJson();
                        manager.WriteFile(str);

                        break;

                    default: break;
                }
            }
        }
    }
}
