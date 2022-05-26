using System;

namespace StrategyPattern
{
    public class TraceLogger : Logger
    {
        public override void LogMessage(string message)
        {
            Console.WriteLine("Message would be written to trace: " + message);
        }

        public override void LogError(string errorMessage)
        {
            Console.WriteLine("Error would be written to trace: " + errorMessage);
        }
    }
}
