using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Interfaces.Logging
{
    public interface ILogger
    {
        void Initialize(string logPath, string name, IMessageWriter messageWriter, ILogReader logReader);
        void Log(string message);
        string[] GetLogs();
    }
}
