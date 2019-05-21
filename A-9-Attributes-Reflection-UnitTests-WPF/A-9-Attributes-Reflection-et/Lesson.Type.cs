using A_9_Attributes_Reflection_et.WithoutAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_9_Attributes_Reflection_et
{
    public static partial class Lesson
    {
        public static void TypeExample()
        {
            var number = 23;
            Type t1 = number.GetType();
            Type t2 = 23.GetType();


            var word = "Hello";
            Type t3 = word.GetType();
            Type t4 = "Hello".GetType();
            

            var date = DateTime.Today;
            Type t5 = date.GetType();
            Type t6 = DateTime.Today.GetType();
            

            var song = new Song();
            Type t7 = song.GetType();
            Type t8 = new Song().GetType();
            

            var array = new string[0];
            Type t9 = array.GetType();
            Type t10 = new string[0].GetType();
        }
    }
}
