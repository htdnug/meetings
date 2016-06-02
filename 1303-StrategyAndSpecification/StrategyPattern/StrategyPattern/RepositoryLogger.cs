using System;

namespace StrategyPattern
{
    public class RepositoryLogger : Logger
    {
        public override void LogMessage(string message)
        {
            Console.WriteLine("Message would be written to repository: " + message);
        }

        public override void LogError(string errorMessage)
        {
            Console.WriteLine("Error would be written to repository: " + errorMessage);
        }
    }
}
