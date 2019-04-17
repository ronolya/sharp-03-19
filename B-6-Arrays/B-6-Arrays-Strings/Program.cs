using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Pyatnashki();
            Console.ReadLine();
        }

        public static void Pyatnashki()
        {
            int[,] mass = new int[3, 3];
            printmass(mass);
            initmass(mass);
            Console.WriteLine();
            printmass(mass);

        }

        private static void printmass(int[,] mass)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                Console.Write($"{mass[i,j]} ");
                }
                Console.WriteLine();
            }
          
        }
        static Random r = new Random();
        private static void initmass(int[,] mass)
        {
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    mass[i, j] = r.Next(10);
                    
                }
                
            }

        }

        public static void PoemExample()
        {
            
        }
    }
}
