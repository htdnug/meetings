using System;
using System.Threading.Tasks;

namespace AsyncAwaitExamples
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                DoSomething();
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

        private static async void DoSomething()
        {
            var text = await ReturnSomethingAsync();

            // some other logic your application needs to do

            Console.WriteLine(text);
        }

        private static async Task<string> ReturnSomethingAsync()
        {
            var value = "text"; 
            return value;
        }
    }
}
