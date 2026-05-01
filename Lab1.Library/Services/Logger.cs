using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Services
{
    public class Logger
    {
        private static readonly Lazy<Logger> _instance =
            new Lazy<Logger>(() => new Logger());
        public static Logger Instance => _instance.Value;
        private static bool _isInitialized = false;
        private string _logPath = string.Empty;
        private Logger() { }

        public void Initialize(string path, string name)
        {
            if(_isInitialized) return;

           
            var logFile = "Log_" + name + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
            var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            var logPath = Path.Combine(logDir, logFile);
            Directory.CreateDirectory(logDir);

            _logPath = logPath;

            _isInitialized = true;
        }

        public void Log(string message)
        {
            if(!_isInitialized)
            {
                throw new NullReferenceException("Logger is not initialized");
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(_logPath, $"[{timestamp}] {message}");
        }
    }
}
