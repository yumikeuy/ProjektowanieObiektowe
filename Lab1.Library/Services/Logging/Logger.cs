using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Logging;

namespace Lab1.Library.Services.Logging
{
    public class Logger : ILogger
    {
        private static readonly Lazy<Logger> _instance =
            new Lazy<Logger>(() => new Logger());
        public static Logger Instance => _instance.Value;
        private static bool _isInitialized = false;
        private IMessageWriter _messageWriter = null!;
        private ILogReader _logReader = null!;
        private readonly object lockObj = new();
        private Logger() { }

        public void Initialize(string logPath, string playerName, IMessageWriter messageWriter, ILogReader logReader)
        {
            if (_isInitialized) return;

            _messageWriter = messageWriter;
            _logReader = logReader;

            var logFile = "Log_" + playerName + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
            var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);
            var _logPath = Path.Combine(logDir, logFile);
            Directory.CreateDirectory(logDir);

            messageWriter.SetPath(_logPath);
            logReader.SetPath(_logPath);

            _isInitialized = true;
        }

        public void Log(string message)
        {
            if (!_isInitialized)
            {
                throw new NullReferenceException("Logger is not initialized");
            }

            lock (lockObj)
            {
                _messageWriter.Write(message);
            }
        }

        public string[] GetLogs()
        {
            lock (lockObj)
            {
                return _logReader.GetLogs();
            }
        }
    }
}
