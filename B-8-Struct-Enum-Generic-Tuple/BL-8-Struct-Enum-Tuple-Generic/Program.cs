using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl_8
{
    public class RectangleClass
    {

        public int Width { get; set; }
        public int Height { get; set; }

        public override bool Equals(object obj)
        {
            RectangleClass rectangle = obj as RectangleClass;

            if ((this.Height == rectangle.Height) & (this.Width == rectangle.Width))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    class Program
    {
        static Random random = new Random();

        public struct Rectangle
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public static void RectangleMassive()
        {

            Rectangle[] rectangle = new Rectangle[100];
            for (int i = 0; i < 100; i++)
            {
                rectangle[i].Height = random.Next(10);
                rectangle[i].Width = random.Next(10);
            }

            int count = 0;

            for (int i = 0; i < 100; i++)
            {
                for (int i2 = 0; i2 < 100; i2++)
                {
                    if (rectangle[i].Equals(rectangle[i2]))
                    {
                        Console.WriteLine($"{rectangle[i].Height} - { rectangle[i2].Height}" +
                            $" {rectangle[i].Width} -  {rectangle[i2].Width}");
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        public static void RectangleMassiveClass()
        {

            RectangleClass rectangleClass = new RectangleClass();
            List<RectangleClass> List = new List<RectangleClass>();

            for (int i = 0; i < 100; i++)
            {
                rectangleClass = new RectangleClass();
                rectangleClass.Height = random.Next(20);
                rectangleClass.Width = random.Next(20);

                List.Add(rectangleClass);
            }

            int count = 0;

            for (int i = 0; i < 100; i++)
            {
                for (int i2 = 0; i2 < 100; i2++)
                {
                    //но для clr'a это всеравно два разных объекта
                    if (List[i].Equals(List[i2]))
                    {
                        Console.WriteLine($"{List[i].Height} - { List[i2].Height}" +
                            $" {List[i].Width} -  {List[i2].Width}");
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }

        static void Main(string[] args)
        {
            RectangleMassive();
            Console.ReadKey();
            Console.Clear();

            RectangleMassiveClass();
            Console.ReadKey();
        }
    }
}
