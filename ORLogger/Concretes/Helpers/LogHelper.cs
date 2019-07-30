using ORLogger.Abstractions;
using ORLogger.Concretes.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORLogger.Concretes.Helpers
{
    /// <summary>
    ///     <english>
    ///         This static class helps for Logging operations.
    ///     </english>
    ///     <turkish>
    ///         Bu statik sınıf Loglama işlemleri için yardımcı olur.
    ///     </turkish>
    /// </summary>
    public static class LogHelper
    {
        private static LogBase _logger = null;
        private static bool _enableLogging = bool.Parse(ConfigurationManager.AppSettings["EnableLogging"]);

        // EventLogger params
        private static string _logName;
        private static string _source;
        private static EventLogEntryType _eventLogEntryType;

        public static void SetEventLoggerParams(string source, string logName, EventLogEntryType eventLogEntryType = EventLogEntryType.Error)
        {
            _source = source;
            _logName = logName;
            _eventLogEntryType = eventLogEntryType;
        }

        // EventLogger params
        private static string _subFolderName;
        public static void SetFileLoggerParams(string subFolderName)
        {
            _subFolderName = subFolderName;
        }
        public static void Log(LogTarget target, string message, bool isError = false)
        {
            if (_enableLogging)
            {
                switch (target)
                {
                    case LogTarget.File:
                        _logger = new FileLogger(_subFolderName);
                        _logger.Log(message, isError);
                        break;
                    case LogTarget.Database:
                        _logger = new DBLogger();
                        _logger.Log(message, isError);
                        break;
                    case LogTarget.EventLog:
                        _logger = new EventLogger(_source, _logName, _eventLogEntryType);
                        _logger.Log(message, isError);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}