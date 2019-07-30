using ORLogger.Abstractions;
using System;
using System.Diagnostics;

namespace ORLogger.Concretes.Logger
{
    public class EventLogger : LogBase
    {
        private EventLog _eventLog;
        private string _entryMessage;
        private string _source;
        private EventLogEntryType _eventLogEntryType;

        public EventLogger(string source, string logName, EventLogEntryType eventLogEntryType)
        {
            _source = source;
            _eventLog = new EventLog(logName);
            _eventLogEntryType = eventLogEntryType;
        }

        public void SetErrorType(EventLogEntryType eventLogEntryType)
        {
            _eventLogEntryType = eventLogEntryType;
        }
        
        public override void Log(string message, bool isError)
        {
            _eventLogEntryType = isError ? EventLogEntryType.Error : _eventLogEntryType ;
            _entryMessage = message;
            _eventLog.Source = _source;
            _eventLog.WriteEntry(_entryMessage, _eventLogEntryType, 101, 1);
        }
    }
}
