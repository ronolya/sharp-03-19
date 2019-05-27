using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advance.Lesson_5
{
    public partial class Program
    {
        public static async Task AsyncAwaitException()
        {
            int devider = 0;
            //var task = Task.Run(() => 2 / devider);

            var task = new Task(() =>
            {
                Console.WriteLine("Running task");
            });

            try
            {
                //Важно поместить в try/catch await
                task.Start();
                //await task;
                Console.WriteLine("After task");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(task?.Exception.InnerException.Message);
                Console.WriteLine($"IsFaulted: {task?.IsFaulted}");
            }
        }

        public static void AsyncExceptionExample()
        {
            try
            {
                DevideByZeroAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Never called");
            }
        }

        public static void AsyncExceptionObservedExample()
        {
            TaskScheduler.UnobservedTaskException += delegate (object sender, UnobservedTaskExceptionEventArgs e)
            {
                Console.WriteLine(e);
            };

            DevideByZeroAsync();

            Thread.Sleep(2000);

            GC.Collect();
        }

        public static void AsyncExceptionUnObservedExample()
        {
            DevideByZeroAsync();

            Thread.Sleep(2000);

            GC.Collect();
        }

        private static void DevideByZeroAsync()
        {
            int devider = 0;
            Task.Run(() => 2 / devider);
        }
    }

    class CustomContext : SynchronizationContext
    {
        public override void OperationStarted()
        {
            Console.WriteLine();
            Console.WriteLine("OperationStarted");
            Console.WriteLine();
        }

        public override void OperationCompleted()
        {
            Console.WriteLine();
            Console.WriteLine("OperationCompleted");
            Console.WriteLine();
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            Console.WriteLine();
            Console.WriteLine("<Posted>");
            Console.Write("    ");
            try
            {
                d.Invoke(state);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown with message '{e.Message}'");
            }
            Console.WriteLine("</Posted>");
            Console.WriteLine();
        }
    }
}
