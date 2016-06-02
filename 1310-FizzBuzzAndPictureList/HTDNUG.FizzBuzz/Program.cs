using System;

namespace HTDNUG.FizzBuzz
{
    /// <summary>
    /// Write a program that prints the numbers from 1 to 100. But for multiples of three print "Fizz" 
    /// instead of the number and for the multiples of five print "Buzz". For numbers which are 
    /// multiples of both three and five print "FizzBuzz".
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                    }
                    else if (i % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine(i);    
                    }
                }
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
    }
}
