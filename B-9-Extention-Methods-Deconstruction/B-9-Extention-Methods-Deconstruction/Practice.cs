using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Lesson_9.Practice
{

    public struct Coordinate
    {

       public int a1 { get; set; }
       public int a2 { get; set; }

        public void Deconstruct(out int a1, out int a2)
        {
            a1 = this.a1;
            a2 = this.a2;
        }
    }

    public  class Practice
    {
        Random ran = new  Random();
        /// <summary>
        /// L9-P-EX-1/2
        /// Создать структуру Coordinates (трехмерных). 
        /// Добавить экземплярный метод деконструкции значений координат.
        /// Вывести на консоль длину вектора по координатам.
        /// </summary>
        public  void L9_P_EX_1_from_2()
        {
            Coordinate[] coordinate = new Coordinate[3];
            double c = 0;
            for (int i = 0; i < coordinate.Length; i++)
            {
                coordinate[i].a1 = ran.Next(5);
                coordinate[i].a2 = ran.Next(5);
                (int a1, int a2) = coordinate[i];

                int coord = a1 * a2;
                c += Math.Sqrt( Math.Pow(coord, 2)); 
            }
            Console.WriteLine();
            Console.WriteLine(c);

        }

        /// <summary>
        /// L9-P-EX-2/2. 
        /// Создать деконструктор для обьекта DateTime 
        /// (год, месяц, день, час, минуты, секунды). 
        /// Получить и вывести на консоль текущее время.
        /// Использовать пустые параметры.
        /// </summary>
        /// 

        public  void L9_P_EX_2_from_2()
        {
            var date = DateTime.Now;
            MyDateTime myDate = new MyDateTime(date);

            (int year, int month, int day, int hour, int minute,  _ ) = myDate;

            Console.Write($"{year} : {month} : {day}: { hour} : {minute}");
        }
    }
}
