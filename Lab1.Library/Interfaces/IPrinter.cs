using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IPrinter
    {
        public void Add(ITextConvertible printable);
        public void Print();
        public void PrepareConsole();
    }
}
