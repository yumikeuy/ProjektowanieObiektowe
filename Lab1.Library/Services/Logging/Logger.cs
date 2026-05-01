using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Logger() { }

        public void Initialize(IMessageWriter messageWriter)
        {
            if (_isInitialized) return;

            _messageWriter = messageWriter;

            _isInitialized = true;
        }

        public void Log(string message)
        {
            if (!_isInitialized)
            {
                throw new NullReferenceException("Logger is not initialized");
            }

            _messageWriter.Write(message);
        }
    }
}
