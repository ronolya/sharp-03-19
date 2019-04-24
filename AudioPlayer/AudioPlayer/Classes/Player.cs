using AudioPleer;
using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using AudioPlayer.Classes;

namespace AudioPleyr
{
    public class Player
    {
     
        private const int maxVolume = 100;
        private bool  playing;
        [Flags]
        public enum LyriesEnum
        {
            Folk ,
            Country,
            Latin ,
            Blues ,
            Rhythm,
            Jazz 
         
        }
        public int CurrentSong { get; private set; }
        private int volume;
        public int Volume
        {
            get { return volume; }
            set
            {
                if (value >= 0 && value <= maxVolume)
                {
                    volume = value;
                    Console.WriteLine($"Текущая громкость {value}");
                }

            }
        }
        private bool isLock;
        public bool IsLock
        {
            get => isLock;
            set
            {
                isLock = value;
                if (value)
                    Console.WriteLine("Плеер заблокирован");
                else
                    Console.WriteLine("Плеер разблокирован");

            }
        }
        public bool Playing { get => playing; }

        FileManager manager;
        public List<Song> Songs;
        public Player()
        {
            manager = new FileManager();
            Songs = new List<Song>();
        }
        public  void SortByTitle()
        {

            Songs.SortExt<Song>(new SongComparer());
            //Songs =  Songs.SortExt();
        }

        public void Shuffle()
        {
            Songs = Songs.ShuffleExt();
        }


        public string SerializeJson()
        {

            return JsonConvert.SerializeObject(Songs, Formatting.Indented);
        }
        public async void DeserializeJson()
        {
            string jsonStr = await manager.ReadFile();
            Songs = JsonConvert.DeserializeObject<List<Song>>(jsonStr);
        }
        public void Like()
        {
            Songs[CurrentSong].Like = true;
        }
        public void Dislike()
        {
            Songs[CurrentSong].Dislike = true;
        }
       
        public void Play()
        {
            for (int i = 0; i < Songs.Count; i++)
            {
                CurrentSong = i;
                ( string title,  Artist artist,  string lyries, _ ,  bool? like,  bool? dislike) = Songs[i];

                var x = like.HasValue;
                
              
                    if (like.Value)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                else if (dislike.HasValue)
                
                    if (dislike.Value)
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                

                else Console.ForegroundColor = ConsoleColor.Black;
               
                Console.WriteLine($"  {title.SubstringExt()} - {artist.Name}" +
                    $"Album:{ artist.Album.Name} - { artist.Album.Age}");
            
                int temp = Convert.ToInt32(lyries);
                if (temp  == ((int)LyriesEnum.Blues | (int)LyriesEnum.Country))
                    Console.WriteLine($"Lirica: { LyriesEnum.Blues }");
             
                Thread.Sleep(10000);
            }
          
            var jsonStr = SerializeJson();
            manager.WriteFile(jsonStr);
        }
        internal void FilterByGenre(Program.LyriesEnum lyriesEnum)
        {
            foreach (var item in Songs)
            {
                if (Convert.ToInt32(item.Lyries) == (int)lyriesEnum)
                {
                    Console.WriteLine($"{item.Title} - {item.Artist.Name} " +
                        $"Album:{ item.Artist.Album.Name}- { item.Artist.Album.Age} Lirica: {lyriesEnum} ");
                }
            }
        }
        public void PlayAdd(Song song)
        {

            Songs.Add(song);
        }
        public void PlayAdd(Song song1, Song song2)
        {
            Songs.Add(song1);
            Songs.Add(song2);
        }
        public void PlayAdd(params Song[] song)
        {
            for (int i = 0; i < song.Length; i++)
                Songs.Add(song[i]);
        }
        public void Stop()
        {
            playing = false;
        }
        public void Lock()
        {
            IsLock = true;
        }
        public void Unlock()
        {
            IsLock = false;

        }
        public void VolumeUp()
        {
            volume += 5;
            Console.WriteLine("Volume is: " + volume);
        }
        public void VolumeDown()
        {
            volume -= 5;
            Console.WriteLine("Volume is: " + volume);
        }

    }
}
