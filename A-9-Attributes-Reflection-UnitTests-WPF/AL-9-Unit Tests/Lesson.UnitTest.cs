using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_9_Unit_Tests
{
    public static partial class Lesson
    {        
        public static void DepCalculatorSum_Test()
        {
            Console.WriteLine("Tesing DepCalculator.Sum");

            var dc = new DepCalculator();
            var r = dc.Sum(2, 5);

            if (r == 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DepCalculator.Sum: Passed.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DepCalculator.Sum: Failed.");
                Console.WriteLine($"Expecting {7}, recieved: {r}");
            }

            Console.ResetColor();

            Console.WriteLine("----------------");
        }

        public static void DepCalculatorMultiple_Test()
        {
            Console.WriteLine("Tesing DepCalculator.Multiple");

            var dc = new DepCalculator();
            var r = dc.Multiple(2, 5);
            var expecting = 10;

            if (r == expecting)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DepCalculator.Multiple: Passed.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DepCalculator.Sum: Multiple.");
                Console.WriteLine($"Expecting {expecting}, recieved: {r}");
            }

            Console.ResetColor();

            Console.WriteLine("----------------");
        }
    }
}
