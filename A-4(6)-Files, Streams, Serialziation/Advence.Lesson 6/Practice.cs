using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Advence.Lesson_6
{
    public partial class Practice
    {
        /// <summary>
        /// AL6-P1/7-DirInfo. Вывести на консоль следующую информацию о каталоге “c://Program Files”:
        /// Имя
        /// Дата создания
        /// </summary>
        public static void AL6_P1_7_DirInfo()
        {
            var directoryInfo = new DirectoryInfo("C://Program Files");
            Console.WriteLine(directoryInfo.FullName + directoryInfo.CreationTime);
        }


        /// <summary>
        /// AL6-P2/7-FileInfo. Получить список файлов каталога и для каждого вывести значение:
        /// Имя
        /// Дата создания
        /// Размер 
        /// </summary>
        public static void AL6_P2_7_FileInfo()
        {
            var directoryInfo = new DirectoryInfo("C://Users//Busyona//Downloads");
            var file_mas = directoryInfo.GetFiles();

            foreach (var item in file_mas)
            {
                Console.WriteLine(item.FullName + item.CreationTime+ item.Length);
            }

        }

        /// <summary>
        /// AL6-P3/7-CreateDir. Создать пустую директорию “c://Program Files Copy”.
        /// </summary>
        public static void AL6_P3_7_CreateDir()
        {
            Directory.CreateDirectory("C://Users//Busyona//Downloads//2");

        }


        /// <summary>
        /// AL6-P4/7-CopyFile. Скопировать первый файл из Program Files в новую папку.
        /// </summary>
        public static void AL6_P4_7_CopyFile()
        {
            var directoryInfo = new DirectoryInfo("C://Users//Busyona//Downloads//");
            var file_mas = directoryInfo.GetFiles();
            file_mas[0].CopyTo("C://Users//Busyona//Downloads//2//"+file_mas[0].Name);

        }

        /// <summary>
        /// AL6-P5/7-FileChat. Написать программу имитирующую чат. 
        /// Пускай в ней будут по очереди запрашивается реплики для User 1 и 
        /// User 2 (используйте цикл из 5-10 итераций).  
        /// Сохраняйте данные реплики с ником пользователя и датой в файл на диске.
        /// </summary>
        public static void AL6_P5_7_FileChat()
        {
            Console.WriteLine("first name:");
            string name1 = Console.ReadLine();
            Console.WriteLine("second name:");
            string name2 = Console.ReadLine();

            using(StreamWriter sw = new StreamWriter("cha.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{name1} phrase:");

                    sw.Write(name1 + " " + Console.ReadLine() + " " + DateTime.Now);
                    sw.WriteLine();
                    Console.WriteLine($"{name2} phrase");
                    sw.Write(name2 + " " + Console.ReadLine() + " " + DateTime.Now);
                    sw.WriteLine();
                    sw.Flush();
                }
            }
        }

        /// <summary>
        /// AL6-P6/7-ConsoleSrlz. (Демонстрация). 
        /// Сериализовать обьект класса Song в XML.Вывести на консоль.
        /// Десериализовать XML из строковой переменной в объект.
        /// </summary>
        public static void AL6_P6_7_ConsoleSrlzn()
        {
            Song song = new Song()
            {
                Title = "Title 1",
                Duration = 247,
                Lyrics = "Lyrics 1"
            };
           
        }

        /// <summary>
        /// AL6-P7/7-FileSrlz.
        /// Отредактировать предыдущий пример для поддержки сериализации и десериализации в файл.
        /// </summary>
        public static void AL6_P7_7_FileSrlz()
        {

        }

    }
}
