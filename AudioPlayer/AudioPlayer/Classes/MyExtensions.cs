using AudioPleer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.Classes
{
    public static class MyExtensions
    {
       static Random random = new Random();
        public static void SortExt<T>(this List<T> t, IComparer<T> comparer)
        {
         
            for (int i = 0; i < t.Count; i++)
            {
                for (int j = 0; j < t.Count; j++)
                {
                   if(comparer.Compare(t[i],t[j])>=1)
                    {
                        var tmp = t[j];
                        t[j] = t[i];
                        t[i] = tmp;
                    }
                }
            }
        }

        public static List<Song> SortExt(this List<Song> Songs)
        {
            List<string> title = new List<string>();

            foreach (var item in Songs)
                title.Add(item.Title);

            title.Sort();

            for (int i = 0; i < title.Count; i++)
            {
                for (int i2 = 0; i2 < title.Count; i2++)
                {
                    if (title[i] == Songs[i2].Title)
                        Songs[i] = Songs[i2];
                }
            }

            return Songs;

        }
        public static List<Song> ShuffleExt(this List<Song> Songs)
        {

            List<Song> tmp = new List<Song>();
            foreach (var item in Songs)
            {
                int j = random.Next(tmp.Count + 1);
                if (j == tmp.Count)
                    tmp.Add(item);
                else
                {
                    tmp.Add(tmp[j]);
                    tmp[j] = item;
                }
            }

            return tmp;
        }

        public static string SubstringExt(this string str)
        {
            if (str.Length >= 13)
                return str.Substring(0, 13) + "...";

            return str;
        }

    }

   
    public interface IComparer<T>
    {
        int Compare(T obj1, T obj2);
    }

    public class SongComparer : IComparer<Song>
    {
        public int Compare(Song obj1, Song obj2)
        {
            int number = String.Compare(obj1.Title, obj2.Title);
            if(number<0)
            {
                return 1;
            }
            else if(number==0)
            {
                return 0;
            }
         
            return -1;
        }
    }
    public class ArtistComparer : IComparer<Artist>
    {
        public int Compare(Artist obj1, Artist obj2)
        {
            int number = String.Compare(obj1.Name, obj2.Name);
            if (number < 0)
            {
                return 1;
            }
            else if (number == 0)
            {
                return 0;
            }

            return -1;
        }
    }

}
