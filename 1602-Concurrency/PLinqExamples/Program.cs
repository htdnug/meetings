using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PLinqExamples
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                HandleSequentiallyForeach();
                HandleSequentiallyLinq();
                HandleInParallelLinqSqlSyntax();
                HandleInParallelLinqMethodSyntax();
                HandleInParallelForeachMethodSyntax();
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

        private static void HandleSequentiallyForeach()
        {
            var source = Enumerable.Range(1, 20000);
            var watch = new Stopwatch();
            watch.Start();

            var list = new List<int>();
            foreach (var num in source)
            {
                if (num % 10 == 0)
                {
                    list.Add(num);
                }
            }
            
            watch.Stop();
            Console.WriteLine("Processed sequentially (foreach) in {0} milliseconds.", watch.ElapsedMilliseconds);
        }

        private static void HandleSequentiallyLinq()
        {
            var source = Enumerable.Range(1, 20000);
            var watch = new Stopwatch();
            watch.Start();

            var query = 
                (from num in source
                where num % 10 == 0
                select num).ToArray();

            watch.Stop();
            Console.WriteLine("Processed sequentially (linq) in {0} milliseconds.", watch.ElapsedMilliseconds);
        }

        private static void HandleInParallelLinqSqlSyntax()
        {
            var source = Enumerable.Range(1, 20000);
            var watch = new Stopwatch();
            watch.Start();

            var query =
                (from num in source.AsParallel()
                where num % 10 == 0
                select num).ToArray();

            watch.Stop();
            Console.WriteLine("Processed in parallel (sql) in {0} milliseconds.", watch.ElapsedMilliseconds);
        }

        private static void HandleInParallelLinqMethodSyntax()
        {
            var source = Enumerable.Range(1, 20000);
            var watch = new Stopwatch();
            watch.Start();

            var query = source.AsParallel()
                .Where(x => x % 10 == 0)
                .Select(x => x);

            watch.Stop();
            Console.WriteLine("Processed in parallel (method) in {0} milliseconds.", watch.ElapsedMilliseconds);
        }

        private static void HandleInParallelForeachMethodSyntax()
        {
            var source = Enumerable.Range(1, 20000);
            var watch = new Stopwatch();
            watch.Start();

            var bag = new ConcurrentBag<int>();
            Parallel.ForEach(source, num => {
                if (num % 10 == 0)
                {
                    bag.Add(num);
                }
            });
            var list = bag.ToArray();

            watch.Stop();
            Console.WriteLine("Processed in parallel (foreach) in {0} milliseconds.", watch.ElapsedMilliseconds);
        }
    }
}
