using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Advenced.Lesson_4
{
    public partial class Practice
    {
        /// <summary>
        /// AL4-P1/5.InstanceCounter. 
        /// AL4-P2/5.InstanceCounterWithHeapSize.
        /// AL4-P3/5.InstanceCounterWithGCCollect.
        /// </summary>
        public static void AL4_P1_P2_P3_5_InstanceCounter()
        {

        }

        /// <summary>
        /// AL4-P4/5. IDisposable. 
        /// AL4-P4/5. IDisposableWithSuppress. 
        /// </summary>
        public static void AL4_P4_P5_5_InstanceCounter()
        {
          //  User user;
            for (int i = 0; i < 50000000; i++)
            {
                var user = new User();
                
                    if (i % 50000 == 0)
                    {
                        //Console.WriteLine( $"memory before  - {GC.GetTotalMemory(false)}");
                        Console.WriteLine(User.counter);
                    }
              
                
                

            }
            Console.WriteLine(User.counter);
        }
    }
    public class User: IDisposable
        {
        public static int counter =  0 ;
        bool isDisposed { get; set; }
        public void Dispose()
        {
            isDisposed = true;
            counter--;
            GC.SuppressFinalize(this);
        }
        public User()
        {
            counter++;
        }
        ~User()
        {
            //counter--;
            if (isDisposed == false) { Dispose(); }
            
        }
    }

}
