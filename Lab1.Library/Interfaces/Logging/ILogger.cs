using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Logging
{
    public interface ILogger
    {
        void Initialize(IMessageWriter messageWriter);
        void Log(string message);
    }
}
