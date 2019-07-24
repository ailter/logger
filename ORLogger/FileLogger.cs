using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORLogger
{
    public class FileLogger : ILogger
    {
        private string _baseDirectory;
        private string _fileName;
        private string _content;

        public FileLogger()
        {
            _baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "error\\";
            _fileName = string.Empty;
            _content = string.Empty;
        }

        public void Log(Exception e)
        {
            _fileName = string.Format("Error_{0}.log", Guid.NewGuid().ToString().Replace("-", "").ToUpper());
            if (!Directory.Exists(_baseDirectory))
                Directory.CreateDirectory(_baseDirectory);

            _content += string.Format("{0}{1}", DateTime.Now, Environment.NewLine);
            _content += string.Format("Exception: {0}{1}", e.Message, Environment.NewLine);
            _content += string.Format("Stack Trace: {0}{1}", e.StackTrace, Environment.NewLine);

            File.WriteAllText(_baseDirectory + _fileName, _content);
        }
    }
}
