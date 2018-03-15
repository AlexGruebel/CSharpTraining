using System;
using Microsoft.Extensions.Logging;

namespace Packt.CS7{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void Dispose()
        {}

        protected virtual void Dispose(bool disposing)
        {}
    }

    public class ConsoleLogger : ILogger
    {

        //unwichtig jetzt --> schau is dir später an
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

    
        public bool IsEnabled(LogLevel logLevel)
        {
            switch(logLevel){
                case LogLevel.Information:
                case LogLevel.Trace:
                case LogLevel.None:
                return false;
                case LogLevel.Critical:
                case LogLevel.Debug:
                case LogLevel.Error:
                case LogLevel.Warning:
                default:
                return true;
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

            if(eventId.Id == 200100){
            Console.WriteLine($"Level: {logLevel}, EventId: {eventId.Id}, EventName: {eventId.Name}");

            if(state!=null){
                Console.Write($"State: {state}");
            }

            if(exception!=null){
                Console.Write($"Exception {exception.Message}");
            }
            Console.WriteLine();
            }
        }
    }
}