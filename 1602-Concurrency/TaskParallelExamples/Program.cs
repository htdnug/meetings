using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelExamples
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                Example01();
                Example02();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static void Example01()
        {
            Thread.CurrentThread.Name = "Main";

            // Define and run the task.
            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));
            
            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);

            taskA.Wait();
        }

        private static void Example02()
        {
            var random = new Random();
            Parallel.Invoke(
                () => {
                    Thread.Sleep(random.Next(3000));
                    Console.WriteLine("Hello from Task A");
                }, 
                () => {
                    Thread.Sleep(random.Next(3000));
                    Console.WriteLine("Hello from Task B");
                },
                () => {
                    Thread.Sleep(random.Next(3000));
                    Console.WriteLine("Hello from Task C");
                }
            );
        }
    }
}
