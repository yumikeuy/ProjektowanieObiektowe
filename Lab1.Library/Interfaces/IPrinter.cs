using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IPrinter
    {
        public void Print(ITextConvertible printable);
        public void PrepareConsole();
    }
}
