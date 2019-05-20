using System;
using System.Collections.Generic;
using System.IO;

namespace Player
{
    public abstract class BasePlayer<T> where T: PlayingItem, new()
    {
        private const int _maxVolume = 100;

        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }
            private set
            {
                if(value > _maxVolume)
                {
                    _volume = _maxVolume;
                }
                else if(value < 0)
                {
                    _volume = 0;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        bool IsLock;
        public List<T> Items { get; private set; } = new List<T>();

        public abstract void Play();

        public void VolumeUp()
        {
            Volume += 5;
            Console.WriteLine("Volume is: " + Volume);
        }

        public void VolumeDown()
        {
            Volume -= 5;
            Console.WriteLine("Volume is: " + Volume);
        }

        public void Load(string path)
        {
            foreach (var item in Directory.GetFiles(path))
            {
                Items.Add(new T()
                {
                    Title = item
                });
            }
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
