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
        static void Main(string[] args)
        {
            /*Add(new string[] { "song 1", "song 2" });
            Add(new string[] { "song 1" });

            Add2("song 2", "song 3", "song 4");
            Add2("song 2");*/


            Console.ReadLine();
        }

        public static void MathExample()
        {
            var m = new Math();

            var x1 = 1;
            var x2 = 5;
            var x3 = 5;

            Console.WriteLine($"{x1}, {x2}, {x3}");

            var r = m.Add(ref x1, x2, x3);

            Console.WriteLine($"{x1}, {x2}, {x3}");

            //Console.WriteLine($"{x1} + {x2} + {x3} = {r}");


            var word = int.Parse(Console.ReadLine());

            int nubmerOut;

            if (int.TryParse(Console.ReadLine(), out nubmerOut))
            {
                Console.WriteLine(nubmerOut);
            }
        }
    }

    public class Math
    {
        public int Add(ref int a, int b, int c)
        {
            Console.WriteLine($"{a}, {b}, {c}");

            a = a * 3;

            Console.WriteLine($"{a}, {b}, {c}");
            return a + b + c;
        }
    }    

}
