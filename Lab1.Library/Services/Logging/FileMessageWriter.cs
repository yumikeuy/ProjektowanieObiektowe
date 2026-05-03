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
        private string _logPath = null!;

        public void SetPath(string path)
        {
            _logPath = path;
        }

        public void Write(string message)
        {
            if(_logPath == null) throw new NullReferenceException("Logging path not specified.");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(_logPath, $"[{timestamp}] :   {message}\n");
        }
    }
}
