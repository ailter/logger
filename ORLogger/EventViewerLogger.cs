using System;
using System.Diagnostics;

namespace ORLogger
{
    public class EventViewerLogger : ILogger
    {
        private EventLog _eventLog;
        private string _entryMessage;
        private string _source;
        private EventLogEntryType _eventLogEntryType;
        public EventViewerLogger(string source, string logName)
        {
            _source = source;
            _eventLog = new EventLog(logName);
            _eventLogEntryType = EventLogEntryType.Error;
        }

        public EventViewerLogger(string source, string logName, EventLogEntryType eventLogEntryType)
        {
            _source = source;
            _eventLog = new EventLog(logName);
            _eventLogEntryType = eventLogEntryType;
        }


        public void Log(Exception e)
        {
            _entryMessage = string.Format("{0}: {1}", e.Message, e.StackTrace);
            _eventLog.Source = _source;
            _eventLog.WriteEntry(_entryMessage, _eventLogEntryType, 101, 1);
        }
    }
}
