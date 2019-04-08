using System;
namespace Base.Lesson_5
{
    public partial class Lesson
    {
        public static void RecursionExample()
        {
            var grandma1 = new Person("Lena");
            var grandpa1 = new Person("Petya");
            var grandma2 = new Person("Anya");
            var grandpa2 = new Person("Vitya");

            var mama = new Person("Vika")
            {
                Parents = new Person[] { grandma1, grandpa1 }
            };

            var papa = new Person("Andrey")
            {
                Parents = new Person[] { grandma2, grandpa2 }
            };

            var me = new Person("Olga")
            {
                Parents = new Person[] { mama, papa }
            };

            ShowRelatives(me);
        }


        public class Person
        {
            public Person(string name)
            {
                this.Name = name;
            }

            public string Name { get; set; }
            public Person[] Parents { get; set; }
        }

        public static void ShowRelatives(Person person)
        {
            if(person == null || person.Parents == null) return;

            foreach (Person p in person.Parents)
            {
                Console.Write(p.Name);
                ShowRelatives(p);
            }
        }
    }
}
