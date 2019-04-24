using System;

namespace AudioPleer
{
    public class Album
    {
        private DateTime date;
        private string name;
        public string Name { get => name; set => name = value; }

        private int age;
        public int Age
        { get => age;
            set
            {
                if (value<=date.Year)
                    age = value;

            }
        }

        internal Album()
        {
            date = DateTime.Now;
            name = "Unkmow Album";
            age = default(int); //0
                
        }        

        internal Album(string name, int age = default(int))
        {
            this.name = name;
            this.age = age;

        }
    }
}
