using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_8_Struct_Enum_Tuple_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Practice.Lb8_P2_3();

            Lesson.EnumExample();

            //Fruits blabla = (Fruits)4;
            
            var numbers = new [] { 1, 4, 2, 7, 8 };
            SortUn<int>(numbers, new IntComparer());

            var nbs = new Neighbor[]
            {
                new Neighbor { flatNumber = 5, name = "Olga"},
                new Neighbor { flatNumber = 8, name = "Vika"},
                new Neighbor { flatNumber = 3, name = "Lena"},
            };

            SortUn<Neighbor>(nbs, new NeibourComparer());

            Console.ReadLine();
        }

        private const int bananos = 4;
        
             

        private static void SortUn<TSortingType>(TSortingType[] numbers, IComparer comparer)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                //if (numbers[i - 1].flatNumber > numbers[i].flatNumber)
                if (comparer.Compare(numbers[i - 1], numbers[i]) >= 1)
                {
                    var temp = numbers[i - 1];
                    numbers[i - 1] = numbers[i];
                    numbers[i] = temp;
                }
            }
        }

        class Neighbour
        {
            public string Name;
            public int Number;
        }

        public interface IComparer<T>
        {
            int Compare(T obj1, T obj2);
        }

        public class IntComparer : IComparer<int>
        {
            public int Compare(int obj1, int obj2)
            {
                if (obj1 > obj2)
                {
                    return 1;
                }
                else if (obj1  == obj2)
                {
                    return 0;
                }

                return -1;
            }
        }

        public class NeibourComparer : IComparer<Neighbor>
        {
            public int Compare(Neighbor obj1, Neighbor obj2)
            {
                if (obj1.flatNumber > (obj2).flatNumber)
                {
                    return 1;
                }
                else if (obj1.flatNumber == obj2.flatNumber)
                {
                    return 0;
                }

                return -1;
            }
        }
    }
}
