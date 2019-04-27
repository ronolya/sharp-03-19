using Advanced_Lesson_1_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Lesson_1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lesson.AbstractionShapeExample();
            //Lesson.OverloadingExample();
            //Lesson.InheritanceTransportExample();

            //Practice.A_L1_P7_OperatorsOverloading();

            Linq();

            var a = new SomeClass();

            Console.ReadKey();
        }

        public static void Linq()
        {
            var list = new List<Transport>()
            {
                new Transport() { Weight = 23, Number = "sdfasdfsadf" },
                new Transport() { Weight = 101, Number = "aaaaaa" }
            };

            var heavyTransport = list
                .Where(FilterHeavyTransport)
                //.Sum(x => x.Weight);
                //.Select(x => x.Number);
                .Select(x => new
                {
                    x.Number,
                    x.Weight
                })
                .OrderBy(x => x.Number);


            var heavyTransportLinq =
                from transport in list
                where transport.Weight > 100
                orderby transport.Number
                select new
                {
                    transport.Number,
                    transport.Weight
                } ;

            foreach (var item in heavyTransport)
            {
                Console.WriteLine($"Number: {item.Number}: {item.Weight}");
            }
        }

        public static bool FilterHeavyTransport(Transport x) {
            return x.Weight > 100;
        }
}
}
