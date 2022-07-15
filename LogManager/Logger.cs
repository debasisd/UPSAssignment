using System;
using NLog;

namespace LogManager
{
    public class Logger
    {
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();

//Added comment to the logger 
        public void LogException(Exception ex)
        {
            _logger.Fatal(ex);
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }
        public void LogTrace(string message)
        {
            _logger.Trace(message);
        }
    }
}
