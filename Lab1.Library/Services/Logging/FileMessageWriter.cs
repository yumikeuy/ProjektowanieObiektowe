using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lab1.Library.Interfaces.Logging;

namespace Lab1.Library.Services.Logging
{
    public class FileMessageWriter : IMessageWriter
    {
        private string _logPath = string.Empty;

        public FileMessageWriter(string path, string name)
        {
            var logFile = "Log_" + name + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
            var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            var logPath = Path.Combine(logDir, logFile);
            Directory.CreateDirectory(logDir);

            _logPath = logPath;
        }

        public void Write(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(_logPath, $"[{timestamp}] :\t{message}\n");
        }
    }
}
