using System;

namespace StrategyPattern
{
    public class LegacyLoggingService : ILoggingService
    {
        public void LogMessage(LoggingStrategy loggingStrategy, string message)
        {
            switch (loggingStrategy)
            {
                case LoggingStrategy.Event:
                    LogToEvent(message);
                    break;
                case LoggingStrategy.Repository:
                    LogToRepository(message);
                    break;
                case LoggingStrategy.Trace:
                    LogToTrace(message);
                    break;
            }
        }

        public void LogError(LoggingStrategy loggingStrategy, string errorMessage)
        {
            switch (loggingStrategy)
            {
                case LoggingStrategy.Event:
                    ErrorToEvent(errorMessage);
                    break;
                case LoggingStrategy.Repository:
                    ErrorToRepository(errorMessage);
                    break;
                case LoggingStrategy.Trace:
                    ErrorToTrace(errorMessage);
                    break;
            }
        }

        private void ErrorToEvent(string errorMessage)
        {
            Console.WriteLine("Error would be written to event log: " + errorMessage);
        }

        private void ErrorToRepository(string errorMessage)
        {
            Console.WriteLine("Error would be written to repository: " + errorMessage);
        }

        private void ErrorToTrace(string errorMessage)
        {
            Console.WriteLine("Error would be written to trace: " + errorMessage);
        }

        private void LogToEvent(string message)
        {
            Console.WriteLine("Message would be written to event log: " + message);
        }

        private void LogToRepository(string message)
        {
            Console.WriteLine("Message would be written to repository: " + message);
        }

        private void LogToTrace(string message)
        {
            Console.WriteLine("Message would be written to trace: " + message);
        }
    }
}
