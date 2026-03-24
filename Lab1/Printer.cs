using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces;

namespace Lab1.Console
{
    public class Printer : IPrinter
    {
        private ICollection<ITextConvertible> _objectsToPrint = [];

        public void Add(ITextConvertible printable)
        {
            _objectsToPrint.Add(printable);
        }

        public void Print()
        {
            foreach(var printable in _objectsToPrint)
                printable.Text().Print();
        }

        public void PrepareConsole()
        {
            System.Console.CursorVisible = false;
            System.Console.Clear();
        }
    }
}
