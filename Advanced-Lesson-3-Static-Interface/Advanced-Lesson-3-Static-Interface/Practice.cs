using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Practice
    {
        /// <summary>
        /// AL3-P1/3. Создать класс UniqueItem c числовым полем Id. 
        /// Каждый раз, когда создается новый экземпляр данного класса, 
        /// его идентификатор должен увеличиваться на 1 относительно последнего созданного. 
        /// Приложение должно поддерживать возможность начать идентификаторы с любого числа. 
        /// </summary>
        public static void AL3_P1_3()
        {
            for (int i = 0; i < 100; i++)
            {
                var product = new Product(DateTime.Now, "Product" + i);
                Console.WriteLine(product.Id + " " + product.Name + " " + product.ExpirationDate);
            }
        }

        /// <summary>
        /// AL3-P2/3. Отредактировать консольное приложение Printer. 
        /// Заменить базовый абстрактный класс на интерфейс.
        /// </summary>
        public static void AL3_P2_3()
        {

        }


        /// <summary>
        /// AL3-P3/3. Создайте обобщенный метод GuessType<T>(T item), 
        /// который будет принимать переменную обобщенного типа и выводить на консоль, 
        /// что это за тип был передан.
        /// </summary>
        public static void AL3_P3_3()
        {
        }

        public class Product
        {
            public int Id;
            public DateTime ExpirationDate;
            public string Name;

            private static int IdCounter { get; set; }

            public Product(DateTime ExpirationDate, string Name)
            {
                this.Name = Name;
                Id = ++IdCounter;
                this.ExpirationDate = ExpirationDate;
            }

            static Product()
            {
                IdCounter = 1000;
            }
        }
    }
}
