using System;
using StrategyPattern;

namespace StrategyPatternConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //UsingLegacy();
                UsingRefactored();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static void UsingLegacy()
        {
            ILoggingService service = new LegacyLoggingService();
            service.LogMessage(LoggingStrategy.Event, "From event legacy");
            service.LogMessage(LoggingStrategy.Repository, "From repository legacy");
            service.LogMessage(LoggingStrategy.Trace, "From trace legacy");
        }

        private static void UsingRefactored()
        {
            ILoggingService service = new RefactoredLoggingService();
            service.LogMessage(LoggingStrategy.Event, "From event refactored");
            service.LogMessage(LoggingStrategy.Repository, "From repository refactored");
            service.LogMessage(LoggingStrategy.Trace, "From trace refactored");
        }
    }
}
