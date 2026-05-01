using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Logging
{
    public interface IMessageWriter
    {
        void Write(string message);
    }
}
