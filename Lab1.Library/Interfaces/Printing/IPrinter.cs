using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Printing
{
    public interface IPrinter
    {
        public void Add(ITextConvertible printable);
        public void Print();
        public void PrepareConsole();
        public bool CheckForResize();
        public void PrintText(string text);
    }
}
