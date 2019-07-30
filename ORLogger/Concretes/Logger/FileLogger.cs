using ORLogger.Abstractions;
using ORLogger.Concretes.Helpers;
using System;
using System.Configuration;
using System.IO;

namespace ORLogger.Concretes.Logger
{
    public class FileLogger : LogBase
    {
        private string _filePath;

        public override void Log(string message, bool isError)
        {
            Guid guid = Guid.NewGuid();
            if (isError)
            {
                lock (lockObj)
                {
                    FileHelper.WriteFile(_filePath, guid.ToString() + "-" + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.") + "Error.txt", message);
                }
            }
            else
            {
                lock (lockObj)
                {
                    FileHelper.WriteFile(_filePath, guid.ToString() + "-" + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.") + "Log.txt", message);
                }
            }
        }

        public FileLogger(string subfolderName = null)
        {
            _filePath = subfolderName != null 
                ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["LoggingPath"], subfolderName).ToString()
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["LoggingPath"]).ToString();
        }
    }
}
