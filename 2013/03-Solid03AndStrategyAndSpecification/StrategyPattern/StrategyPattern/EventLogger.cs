using System;

namespace StrategyPattern
{
    public class EventLogger : Logger
    {
        public override void LogMessage(string message)
        {
            Console.WriteLine("Message would be written to event log: " + message);
        }

        public override void LogError(string errorMessage)
        {
            Console.WriteLine("Error would be written to event log: " + errorMessage);
        }
    }
}
