using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Console
{
    public class Printer
    {
        public void Print(IPrintable printable)
        {
            printable.Print();
        }

        public void PrepareConsole()
        {
            System.Console.CursorVisible = false;
            System.Console.Clear();
        }
    }
}
