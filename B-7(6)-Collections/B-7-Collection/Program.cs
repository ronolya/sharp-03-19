using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_5
{
    class Program
    {
        class Neibghbor
        {
            public string fullName;
            public int flatNumber;
            public int phoneNumber;
        }
        static void Main(string[] args)
        {
            ArrayListExample();

            Console.ReadLine();
        }
        


        public static void ArrayListExample()
        {
            var parts = new Dictionary<int, Neibghbor>();
            parts.Add(1, new Neibghbor { fullName = "Vasia", flatNumber = 1, phoneNumber= 999 });
            parts.Add(3, new Neibghbor { fullName = "Olia", flatNumber = 3, phoneNumber = 888 });
            parts.Add(7, new Neibghbor { fullName = "Oleg", flatNumber = 7, phoneNumber = 777 });
            Console.WriteLine("input flat number");
            int s = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(parts[s].phoneNumber);
        }

        public class Song
        {
            public string Lyrics;

            public override string ToString()
            {
                return this.Lyrics;
            }
        }
    }
}
